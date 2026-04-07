using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{

    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con las compras, incluyendo el registro de nuevas compras, la obtención del historial de compras y la consulta de detalles de una compra específica por su ID.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;

        /// <summary>
        /// Constructor del controlador de compras que inicializa el servicio de lógica de negocio para compras.
        /// </summary>
        /// <param name="compraService"></param>

        public ComprasController(ICompraService compraService)
        {
            _compraService = compraService;
        }


        /// <summary>
        /// Agrega una nueva compra al sistema, procesando la información proporcionada en el cuerpo de la solicitud. El método maneja la lógica de negocio para registrar la compra, calcular el total y generar la factura correspondiente. En caso de éxito, devuelve un mensaje de confirmación junto con los detalles de la factura; en caso de error, devuelve un mensaje de error con la descripción del problema.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Compra compra)
        {
            try
            {
                var resultado = await _compraService.RegistrarCompra(compra);
                return Ok(new { mensaje = "Venta procesada con éxito", factura = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el historial completo de compras registradas en el sistema, incluyendo detalles como la fecha de compra, los productos adquiridos, el total de la compra y la información del cliente. El método devuelve una lista de objetos que representan cada compra realizada.
        /// </summary>
        /// <returns>Lista de objetos que representa una compra realizada</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _compraService.ObtenerHistorial());
        }

        /// <summary>
        /// Obtiene los detalles de una compra específica identificada por su ID. El método busca la compra en el sistema y devuelve la información detallada de la compra, incluyendo los productos adquiridos, el total, la fecha y la información del cliente. Si la compra no se encuentra, devuelve un mensaje de error indicando que no se encontró la compra con el ID proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Detalles de compra</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var compra = await _compraService.ObtenerCompraPorId(id);
            if (compra == null) return NotFound();
            return Ok(compra);
        }
    }
}
