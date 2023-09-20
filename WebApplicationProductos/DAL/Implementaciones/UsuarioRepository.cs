using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplicationProductos.DAL.DataContext;
using WebApplicationProductos.DAL.Interfaces;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;
using XSystem.Security.Cryptography;

namespace WebApplicationProductos.DAL.Implementaciones
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly AplicatiosDbContext _context;
        private string claveSecreta;
        public UsuarioRepository(AplicatiosDbContext context, IConfiguration config) : base(context) 
        { 
            _context = context;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public async Task<bool> IsUniqueUser(string usuario)
        {
            var usuarioDb = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreDeUsuario == usuario);
            if (usuarioDb == null)
                return true;
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            var passworEncriptado = ObtenerMD5(usuarioLoginDTO.Password);
            var usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(
                                            u => u.NombreDeUsuario.ToLower() == usuarioLoginDTO.NombreDeUsuario.ToLower()
                                            && u.Password == passworEncriptado);
            if(usuarioEncontrado==null)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    Usuario = null

                };
            }

            var conductorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioEncontrado.NombreDeUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = conductorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = conductorToken.WriteToken(token),
                Usuario = usuarioEncontrado
            };
            return usuarioLoginRespuestaDTO;
        }
        public async Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var passwordEncriptador = ObtenerMD5(usuarioRegistroDTO.Password);

            var usuarioNuevo = new Usuario()
            {
                NombreDeUsuario = usuarioRegistroDTO.NombreDeUsuario,
                Password = passwordEncriptador,
                Nombre = usuarioRegistroDTO.Nombre,
                Role = usuarioRegistroDTO.Role
            };

            _context.Usuarios.Add(usuarioNuevo);
            await _context.SaveChangesAsync();
            usuarioNuevo.Password = passwordEncriptador;
            return usuarioNuevo;
        }
        public static string ObtenerMD5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string respuesta = "";
            for(int i =0; i < data.Length; i++)
            {
                respuesta += data[i].ToString("x2").ToLower();
            }
            return respuesta;
        }
    }
}
