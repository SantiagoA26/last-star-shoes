using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public ComprasController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _compraService.ObtenerHistorial());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var compra = await _compraService.ObtenerCompraPorId(id);
            if (compra == null) return NotFound();
            return Ok(compra);
        }
    }
}
