using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            try
            {
                var nuevoProducto = await _service.CreateProducto(producto);
                return Ok(nuevoProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _service.GetProductos();
            return Ok(productos);
        }

       
        [HttpGet("filtrar")]
        public async Task<IActionResult> GetProductosFiltrados([FromQuery] string? categoria, [FromQuery] string? genero)
        {
            try
            {
                var productos = await _service.GetProductosFiltrados(categoria, genero);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(string id)
        {
            try
            {
                var producto = await _service.GetProductoById(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(string id, [FromBody] Producto producto)
        {
            try
            {
                var productoActualizado = await _service.UpdateProducto(id, producto);
                return Ok(productoActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(string id)
        {
            try
            {
                var eliminado = await _service.DeleteProducto(id);

                if (!eliminado)
                    return NotFound("Producto no encontrado");

                return Ok("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
