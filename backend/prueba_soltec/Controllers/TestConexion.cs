using System.Data;
using Microsoft.AspNetCore.Mvc;
using prueba_soltec.Data;

namespace prueba_soltec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConexion : Controller
    {
        private readonly AppDbContext _context;
        public TestConexion(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("probarConexion")]
        public async Task<IActionResult> ProbarConexion()
        {
            try
            {
                var conexionSatisfactoria = await _context.Database.CanConnectAsync();
                if (!conexionSatisfactoria)
                {
                    return BadRequest("Error: EF Core no puede conectarse");
                }
                return Ok("Conexion Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al conextar a la base de datos{ex.Message}");
            }
        }
    }
}
