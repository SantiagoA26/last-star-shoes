using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastStarShoesAPI.Controllers
{

    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con los productos, incluyendo creación, obtención, actualización y eliminación de productos. También permite filtrar productos por categoría y género.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        /// <summary>
        /// Constructor del controlador de productos que inicializa el servicio de lógica de negocio para productos.
        /// </summary>
        /// <param name="service"></param>
        public ProductosController(IProductoService service)
        {
            _service = service;
        }


        /// <summary>
        /// Crear un nuevo producto en la base de datos. Recibe un objeto Producto en el cuerpo de la solicitud y devuelve el producto creado con su ID asignado. Maneja errores y devuelve mensajes adecuados en caso de fallos.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        /// <summary>
        /// Obtener una lista de todos los productos registrados en la base de datos. Si no hay productos, devuelve una lista vacía.
        /// </summary>
        /// <returns>Objetos que representan productos </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _service.GetProductos();
            return Ok(productos);
        }


        /// <summary>
        /// Obtener una lista de productos filtrados por categoría y/o género. Permite filtrar los productos según los parámetros opcionales "categoria" y "genero" proporcionados en la consulta. Si no se proporcionan filtros, devuelve todos los productos.
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="genero"></param>
        /// <returns>Productos que coincidan con el filtro</returns>
        [HttpGet("filtrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        /// <summary>
        /// Obtener un producto específico por su ID. Recibe el ID del producto como parámetro en la ruta y devuelve el producto correspondiente si se encuentra. Si no se encuentra el producto, devuelve un mensaje de error adecuado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Producto relacionado al ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Actualizar un producto existente en la base de datos. Recibe el ID del producto a actualizar como parámetro en la ruta y un objeto Producto con los datos actualizados en el cuerpo de la solicitud. Devuelve el producto actualizado si la operación es exitosa o un mensaje de error adecuado en caso de fallos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="producto"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Eliminar un producto de la base de datos. Recibe el ID del producto a eliminar como parámetro en la ruta y devuelve un mensaje indicando si la eliminación fue exitosa o si el producto no se encontró. Maneja errores y devuelve mensajes adecuados en caso de fallos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una acción indicando el resultado de la operación</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
