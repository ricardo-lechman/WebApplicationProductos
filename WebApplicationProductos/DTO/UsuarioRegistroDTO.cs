using System.ComponentModel.DataAnnotations;

namespace WebApplicationProductos.DTO
{
    public class UsuarioRegistroDTO
    {
        [Required(ErrorMessage ="El usuario es obligatorio")]
        public string? NombreDeUsuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }
        public string? Password { get; set; }
        [Required(ErrorMessage = "La Contraseña es obligatorio")]
        public string? Role { get; set; }
    }
}
