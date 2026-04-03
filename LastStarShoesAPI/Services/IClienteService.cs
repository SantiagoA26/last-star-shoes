using LastStarShoesAPI.Models;

namespace LastStarShoesAPI.Services
{
    public interface IClienteService
    {
        Task<Cliente> CreateCliente(Cliente cliente);

   
        Task<List<Cliente>> GetClientes();

     
        Task<Cliente> GetClienteById(string id);

   
        Task<Cliente> UpdateCliente(string id, Cliente cliente);

        Task<bool> DeleteCliente(string id);

    }
}
