using System.ComponentModel.DataAnnotations;

namespace WebApplicationProductos.DTO
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string? NombreDeUsuario { get; set; }

        [Required(ErrorMessage = "La Contraseña es obligatorio")]
        public string? Password { get; set; }
        
    }
}
