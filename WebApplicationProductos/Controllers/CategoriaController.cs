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
    public class CategoriaController : ControllerBase
    {
     
        private readonly IGenericRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CategoriaController(IGenericRepository<Categoria> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CategoriaDTO CategoriaDTO)
        {
            var descripcion = _mapper.Map<Categoria>(CategoriaDTO);
            var respuesta = await _repository.Insertar(descripcion);

            if(!respuesta)
            {
                return BadRequest(respuesta);
            }
            var dto = _mapper.Map<CategoriaDTO>(descripcion);
            return Ok(dto);
        }
    }
}
