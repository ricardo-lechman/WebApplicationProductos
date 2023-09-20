namespace WebApplicationProductos.DAL.Interfaces
{
    public interface IGenericRepository<Entidad> where Entidad : class
    {
        Task<IEnumerable<Entidad>> ObtenerTodos();
        Task<Entidad> Obtener(int id);
        Task<bool> Insertar(Entidad entity);
        Task<bool> Actualizar(Entidad entity);
        Task<bool> Eliminar(int id);
    }
}
