using AutoMapper;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(d => d.FechaDeNacimiento,
                opt => opt.MapFrom(o => o.FechaDeNacimiento.ToString("dd/MM/yyyy")));

             CreateMap<ClienteCreacionDTO, Cliente>()
                .ForMember(d => d.FechaDeNacimiento,
                opt => opt.MapFrom(o => DateTime.Parse(o.FechaDeNacimiento)));

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

            CreateMap<Producto, ProductoDTO>().ReverseMap();

            CreateMap<DetalleDeVenta, DetalleDeVentaDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}