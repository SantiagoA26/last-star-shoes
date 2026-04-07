using LastStarShoesAPI.Models;

namespace LastStarShoesAPI.Services
{
    public interface ICompraService
    {
        
        Task<Compra> RegistrarCompra(Compra compra);
        Task<IEnumerable<Compra>> ObtenerHistorial();
        Task<Compra?> ObtenerCompraPorId(int id);
        Task<IEnumerable<Compra>> ObtenerComprasPorCliente(string idCliente);

    }
}
