using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        // CREAR CLIENTE
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            try
            {
                var nuevoCliente = await _service.CreateCliente(cliente);
                return Ok(nuevoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // LISTAR CLIENTES
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _service.GetClientes();
            return Ok(clientes);
        }

        // OBTENER CLIENTE POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(string id)
        {
            try
            {
                var cliente = await _service.GetClienteById(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ACTUALIZAR CLIENTE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(string id, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteActualizado = await _service.UpdateCliente(id, cliente);
                return Ok(clienteActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ELIMINAR CLIENTE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            try
            {
                var eliminado = await _service.DeleteCliente(id);

                if (!eliminado)
                    return NotFound("Cliente no encontrado");

                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
