using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProductos.DAL.Interfaces;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IGenericRepository<Cliente> _repository;
        private readonly IMapper _mapper;

        public ClienteController(IGenericRepository<Cliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(ClienteCreacionDTO ClienteCreacionDTO)
        {
            var cliente = _mapper.Map<Cliente>(ClienteCreacionDTO);

            var resultado = await _repository.Insertar(cliente);
            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<ClienteDTO>(cliente);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> ObtenerTodos()
        {
            var clientes = await _repository.ObtenerTodos();
            var ClienteDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(ClienteDTO);
        }

        [HttpGet("soloClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Obtener()
        {
            var clientes = await _repository.ObtenerTodos();
            return Ok(clientes);

        }

        
    }
}

