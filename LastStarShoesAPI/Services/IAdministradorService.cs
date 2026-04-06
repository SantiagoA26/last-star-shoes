using LastStarShoesAPI.Models;

namespace LastStarShoesAPI.Services
{
    public interface IAdministradorService
    {
       Task<Administrador> CreateAdministrador(Administrador administrador);
        Task<List<Administrador>> GetAdministradores();
        Task<Administrador> GetAdministradorById(string id);
        Task<Administrador> UpdateAdministrador(string id, Administrador administrador);
        Task<bool> DeleteAdministrador(string id);
    }
}
