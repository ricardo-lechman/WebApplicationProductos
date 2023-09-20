namespace WebApplicationProductos.Models
{
    public class Cliente
    {
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int Dni { get; set; }
    public DateTime FechaDeNacimiento { get; set; }
    public string? Direccion { get; set; }
    public int Telefono { get; set; }
    public string? Email { get; set; }
    }
}
