using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{
    ///<summary>
    /// Controlador para gestionar las operaciones relacionadas con los administradores.
    /// </summary>  
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradorService _service;


        /// <summary>
        /// Constructor del controlador de administradores.
        /// </summary>
        /// <param name="service">El servicio de lógica de negocio para administradores.</param>
        public AdministradoresController(IAdministradorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Crea un nuevo administrador
        /// </summary>
        /// <param name="administrador"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Obtiene una lista de todos los administradores.
        /// </summary>
        /// <returns>Objetos que representan administradores</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdministradores()
        {
            var admins = await _service.GetAdministradores();
            return Ok(admins);
        }


        /// <summary>
        /// Obtener un administrador relacionado con su numero de ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Administrador relacionado al ID ingresado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Actualizar un administrador existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="administrador"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

  
        /// <summary>
        /// Elimina un administrador por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
