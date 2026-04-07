using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{

    ///<summary>
    /// Controlador para gestionar las operaciones relacionadas con los clientes.
    /// </summary>  
    [Route("api/[controller]")]
    [ApiController]
   
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        /// <summary>
        /// Constructor del controlador de clientes que inicializa el servicio.
        /// </summary>
        /// <param name="service">El servicio de lógica de negocio para clientes.</param>
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Crea un nuevo cliente en la base de datos. Se validan los campos obligatorios y se verifica que no exista un cliente con el mismo ID antes de agregarlo.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        /// <summary>
        /// Obtiene una lista de todos los clientes registrados en la base de datos. Si no hay clientes, devuelve una lista vacía.
        /// </summary>
        /// <returns>Objetos que representan clientes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _service.GetClientes();
            return Ok(clientes);
        }

        /// <summary>
        /// Obtiene un cliente específico por su ID. Si el cliente no existe, devuelve un error 404 Not Found con un mensaje descriptivo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un cliente identificado con el ID proporcionado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

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

        /// <summary>
        /// Actualiza la información de un cliente existente. Se valida que el cliente exista antes de intentar actualizarlo, y se manejan posibles errores durante el proceso de actualización.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        /// <summary>
        /// Elimina un cliente de la base de datos utilizando su ID. Se verifica que el cliente exista antes de intentar eliminarlo, y se manejan posibles errores durante el proceso de eliminación.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
