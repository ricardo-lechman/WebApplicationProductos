using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationProductos.DAL.DataContext;
using WebApplicationProductos.DAL.Interfaces;

namespace WebApplicationProductos.DAL.Implementaciones
{
    public class GenericRepository<Entidad> : IGenericRepository<Entidad> where Entidad : class
    {
        private readonly AplicatiosDbContext _context;

        public GenericRepository(AplicatiosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Actualizar(Entidad entity)
        {
            bool resultado = false;

            _context.Set<Entidad>().Update(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await Obtener(id);
            if (entidad == null)
            {
                return false;
            }
            _context.Set<Entidad>().Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Entidad entity)
        {
            bool resultado = false;
            _context.Set<Entidad>().AddAsync(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }

        public async Task<Entidad> Obtener(int id)
        {
            return await _context.Set<Entidad>().FindAsync(id);
        }

        public async Task<IEnumerable<Entidad>> ObtenerTodos()
        {
            return await _context.Set<Entidad>().ToListAsync();
        }
    }
}
