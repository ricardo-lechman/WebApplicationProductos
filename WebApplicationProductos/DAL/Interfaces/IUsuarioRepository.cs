using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.DAL.Interfaces
{
    public interface IUsuarioRepository :IGenericRepository<Usuario>

    {
            Task<bool> IsUniqueUser(string usuario);
            Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO);
            Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO);
    }
}
