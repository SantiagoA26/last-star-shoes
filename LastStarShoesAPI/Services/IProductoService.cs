using LastStarShoesAPI.Models;

namespace LastStarShoesAPI.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();


        Task<Producto?> GetProductoById(string id);


        Task<Producto> CreateProducto(Producto producto);


        Task<Producto?> UpdateProducto(string id, Producto producto);


        Task<bool> DeleteProducto(string id);


        Task<List<Producto>> GetProductosFiltrados(string? categoria, string? genero);
    }
}
