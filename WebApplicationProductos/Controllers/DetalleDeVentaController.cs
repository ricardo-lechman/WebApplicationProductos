using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProductos.DAL.Interfaces;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleDeVentaController : ControllerBase
    {
        private readonly IGenericRepository<DetalleDeVenta> _repository;
        private readonly IMapper _mapper;

        public DetalleDeVentaController(IGenericRepository<DetalleDeVenta> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Autorizacion y chache prueba
        [Authorize(Roles = "admin")]
        [ResponseCache(CacheProfileName = "PorDefecto")]
        [HttpPost]
        public async Task<ActionResult> Crear(DetalleDeVentaDTO DetalleDeVentaDTO)
        {
            var ventas = _mapper.Map<DetalleDeVenta>(DetalleDeVentaDTO);

            var resultado = await _repository.Insertar(ventas);
            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<DetalleDeVentaDTO>(ventas);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleDeVentaDTO>>> ObtenerTodos()
        {
            var ventas = await _repository.ObtenerTodos();
            var DetalleDeVentaDTO = _mapper.Map<IEnumerable<DetalleDeVentaDTO>>(ventas);
            return Ok(DetalleDeVentaDTO);
        }

    }
}
