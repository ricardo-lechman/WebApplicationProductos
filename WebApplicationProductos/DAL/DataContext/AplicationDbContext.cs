using Microsoft.EntityFrameworkCore;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.DAL.DataContext
{
    public class AplicatiosDbContext : DbContext
    {
        public AplicatiosDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().Property(x => x.Nombre).HasMaxLength(75);
            modelBuilder.Entity<Cliente>().Property(x => x.Apellido).HasMaxLength(75);
            modelBuilder.Entity<Cliente>().Property(x => x.Direccion).HasMaxLength(75);
            modelBuilder.Entity<Cliente>().Property(x => x.Telefono).HasMaxLength(15);
            modelBuilder.Entity<Cliente>().Property(x => x.Email).HasMaxLength(150);
            modelBuilder.Entity<Cliente>().Property(x => x.FechaDeNacimiento).HasColumnType("date");


            modelBuilder.Entity<Categoria>().Property(x => x.Nombre).HasMaxLength(75);
            modelBuilder.Entity<Categoria>().Property(x => x.Descripcion).HasMaxLength(500);


            modelBuilder.Entity<Producto>().Property(x => x.NombreProducto).HasMaxLength(150);
            modelBuilder.Entity<Producto>().Property(x => x.Contenido).HasMaxLength(500);
}

        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleDeVenta> DetalleDeVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
