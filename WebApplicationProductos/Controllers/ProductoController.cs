using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProductos.DAL.Interfaces;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _repository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductoDTO>> Obtener(int id)
        {
            var producto = await _repository.Obtener(id);
            if (producto == null)
                return NotFound();

            var ProductoDTO = _mapper.Map<ProductoDTO>(producto);
            return Ok(ProductoDTO);

        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Crear(ProductoCreacionDTO ProductoCreacionDTO)
        {
            var producto = _mapper.Map<Producto>(ProductoCreacionDTO);
            await _repository.Insertar(producto);

            var ProductoDTO = _mapper.Map<ProductoDTO>(producto);
            return CreatedAtAction(nameof(Obtener), new {id = producto.Id }, ProductoDTO);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult>Actualizar(int id, ProductoCreacionDTO productoCreacionDTO)
        {
         var productoDesdeRepo = await _repository.Obtener(id);
         if (productoDesdeRepo == null)
                return NotFound();

            _mapper.Map(productoCreacionDTO, productoDesdeRepo);
            var resultado = await _repository.Actualizar(productoDesdeRepo);
            if (resultado)
                return NoContent();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var productoDesdeRepo = await _repository.Obtener(id);
            if (productoDesdeRepo == null)
                return NotFound();

            var resultado = await _repository.Eliminar(id);
            if (resultado)
                return NoContent();

            return BadRequest();
        }
    }
}
