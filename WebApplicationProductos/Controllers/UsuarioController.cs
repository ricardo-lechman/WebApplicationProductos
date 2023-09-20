using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProductos.DAL.Interfaces;
using WebApplicationProductos.DTO;
using WebApplicationProductos.Models;

namespace WebApplicationProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> _repository;
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;
        protected RespuestaApi _respuesta;

        public UsuarioController(IGenericRepository<Usuario> repository,
                                IUsuarioRepository userRepository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            this._respuesta = new RespuestaApi();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerTodos()
        {
            var usuarios = await _repository.ObtenerTodos();
            var usuarioDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Registro([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var validacionNombre = await _userRepository.IsUniqueUser(usuarioRegistroDTO.NombreDeUsuario);
            if (!validacionNombre)
            {
                _respuesta.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMenssages.Add("El nombre de usuario ya existe");
                return BadRequest(_respuesta);
            }

            var usuario = await _userRepository.Registro(usuarioRegistroDTO);
            if(usuario ==null)
            {
                _respuesta.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMenssages.Add("Error en el registro");
                return BadRequest(_respuesta);
            }
            _respuesta.StatusCode = System.Net.HttpStatusCode.OK;
            _respuesta.IsSuccess = true;
            return Ok(_respuesta);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            var respuestaLogin = await _userRepository.Login(usuarioLoginDTO);
            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuesta.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _respuesta.IsSuccess = false;
                _respuesta.ErrorMenssages.Add("El nombre de usuario o el password son incorrectos");
                return BadRequest(_respuesta);
            }

            _respuesta.StatusCode = System.Net.HttpStatusCode.OK;
            _respuesta.IsSuccess = true;
            _respuesta.Result = respuestaLogin;
            return Ok(_respuesta);
        }
    }

}
