using LastStarShoesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LastStarShoesAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly LaststarShoesDbContext _context;

        public ProductoService(LaststarShoesDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.IdProducto))
                throw new Exception("El ID del producto es obligatorio");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto es obligatorio");

            if (producto.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero");

            if (producto.Stock < 0)
                throw new Exception("El stock no puede ser negativo");

            var categoriasValidas = new List<string> { "Deportivos", "Casuales", "Elegantes", "Urbanos", "Edicion Limitada" };
            if (!categoriasValidas.Contains(producto.Categoria))
                throw new Exception("Categoría no válida");

            var generosValidos = new List<string> { "Masculino", "Femenino", "Unisex" };
            if (!generosValidos.Contains(producto.Genero))
                throw new Exception("Género no válido");

            var existeProducto = await _context.Productos.AnyAsync(p => p.IdProducto == producto.IdProducto);
            if (existeProducto)
                throw new Exception("Ya existe un producto con este ID");

            producto.FechaCreacion = DateTime.Now;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetProductoById(string id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            return producto;
        }

        public async Task<List<Producto>> GetProductosFiltrados(string? categoria, string? genero)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categoria == categoria);

            if (!string.IsNullOrEmpty(genero))
                query = query.Where(p => p.Genero == genero);

            return await query.ToListAsync();
        }

        public async Task<Producto?> UpdateProducto(string id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null)
                throw new Exception("Producto no encontrado");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre es obligatorio");

            // 🔹 Actualización de campos
            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.Categoria = producto.Categoria;
            productoExistente.Genero = producto.Genero;

         
            productoExistente.ImagenUrl = producto.ImagenUrl;

            await _context.SaveChangesAsync();
            return productoExistente;
        }

        public async Task<bool> DeleteProducto(string id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            var tieneVentas = await _context.DetalleCompras.AnyAsync(d => d.IdProducto == id);
            if (tieneVentas)
                throw new Exception("No se puede eliminar el producto porque ya tiene ventas registradas");

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}