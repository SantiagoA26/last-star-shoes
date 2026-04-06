using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradorService _service;

        public AdministradoresController(IAdministradorService service)
        {
            _service = service;
        }

        // Crear administrador
        [HttpPost]
        public async Task<IActionResult> CreateAdministrador([FromBody] Administrador administrador)
        {
            try
            {
                var nuevoAdmin = await _service.CreateAdministrador(administrador);
                return Ok(nuevoAdmin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAdministradores()
        {
            var admins = await _service.GetAdministradores();
            return Ok(admins);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministradorById(string id)
        {
            try
            {
                var admin = await _service.GetAdministradorById(id);
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Actualizar administrador
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdministrador(string id, [FromBody] Administrador administrador)
        {
            try
            {
                var adminActualizado = await _service.UpdateAdministrador(id, administrador);
                return Ok(adminActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(string id)
        {
            try
            {
                var eliminado = await _service.DeleteAdministrador(id);

                if (!eliminado)
                    return NotFound("Administrador no encontrado");

                return Ok("Administrador eliminado correctamente");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
