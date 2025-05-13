using Microsoft.AspNetCore.Mvc;
using prueba_soltec.Interfaces;
using AutoMapper;
using prueba_soltec.DTOs.Usuarios;
using Microsoft.AspNetCore.Authorization;

namespace prueba_soltec.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioService usuarioService, ILogger<UsuariosController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosDto>>> ObtenerTodos()
        {
            try
            {
                var usuarios = await _usuarioService.ObtenerTodosUsuariosAsync();
                return Ok(usuarios);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error al obtener productos");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosDto>> ObtenerPorId(int id)
        {
            try
            {
                var usuario=await _usuarioService.ObtenerUsuariosPorIdAsync(id);
                return Ok(usuario);
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener usuario con ID{id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuariosDto>> Crear([FromBody] UsuariosCrearDto usuariosCrearDto)
        {
            try
            {
                var nuevoUsuario = await _usuarioService.CrearUsuarioAsync(usuariosCrearDto);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoUsuario.Id }, nuevoUsuario);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(500, $"Error interno del servidor {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuariosDto>> Actualizar(int id, [FromBody] UsuariosActualizarDto usuariosActualizarDto)
        {
            try
            {
                var usuarioActualizado=await _usuarioService.ActualizarUsuarioAsync(id, usuariosActualizarDto);
                return Ok(usuarioActualizado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(500, $"Error interno del servidor {ex.Message}");
            }
        }
    }
    
}
