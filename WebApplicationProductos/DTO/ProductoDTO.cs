namespace WebApplicationProductos.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string? NombreProducto { get; set; }
        public int Precio { get; set; }
        public bool Stock { get; set; }
        public string? Contenido { get; set; }
    }
}
