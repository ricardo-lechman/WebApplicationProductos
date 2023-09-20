using WebApplicationProductos.Models;

namespace WebApplicationProductos.DTO
{
    public class UsuarioLoginRespuestaDTO
    {
        public Usuario Usuario { get; set; }
        public string? Token { get; set; }
    }
}
