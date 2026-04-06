using LastStarShoesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LastStarShoesAPI.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly LaststarShoesDbContext _context;

        public AdministradorService(LaststarShoesDbContext context)
        {
            _context = context;
        }

        // crear un nuevo administrador con validaciones básicas para el ID, nombre, email y contraseña, además de verificar que no exista un administrador con el mismo ID o email antes de agregarlo a la base de datos
        public async Task<Administrador> CreateAdministrador(Administrador administrador)
        {
            // 🔹 Validaciones básicas
            if (string.IsNullOrWhiteSpace(administrador.IdAdmin))
                throw new Exception("El ID de administrador es obligatorio");

            if (string.IsNullOrWhiteSpace(administrador.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(administrador.Email) || !administrador.Email.Contains("@"))
                throw new Exception("Email inválido o vacío");

            if (string.IsNullOrWhiteSpace(administrador.Password) || administrador.Password.Length < 6)
                throw new Exception("La contraseña debe tener al menos 6 caracteres");

            // 🔹 Validar si ya existe el ID o el Email
            var existeAdmin = await _context.Administradores
                .AnyAsync(a => a.IdAdmin == administrador.IdAdmin || a.Email == administrador.Email);

            if (existeAdmin)
                throw new Exception("El administrador o el email ya se encuentran registrados");

            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return administrador;
        }

        public async Task<List<Administrador>> GetAdministradores()
        {
            return await _context.Administradores.ToListAsync();
        }


        public async Task<Administrador> GetAdministradorById(string id)
        {
            var admin = await _context.Administradores.FindAsync(id);

            if (admin == null)
                throw new Exception("Administrador no encontrado");

            return admin;
        }

        // Actualiza el administrador existente con el ID proporcionado, permitiendo cambiar solo el nombre, email y opcionalmente la contraseña (con validación de longitud mínima)
        public async Task<Administrador> UpdateAdministrador(string id, Administrador administrador)
        {
            var adminExistente = await _context.Administradores.FindAsync(id);

            if (adminExistente == null)
                throw new Exception("Administrador no encontrado");

            // Validaciones básicas para el nombre y el email (el ID no se puede cambiar)
            if (string.IsNullOrWhiteSpace(administrador.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(administrador.Email))
                throw new Exception("El email es obligatorio");

            // Actualizar solo el nombre y el email (el ID no se puede cambiar)
            adminExistente.Nombre = administrador.Nombre;
            adminExistente.Email = administrador.Email;

            // Solo actualizar la contraseña si se proporciona una nueva (y cumple con los requisitos)
            if (!string.IsNullOrWhiteSpace(administrador.Password))
            {
                if (administrador.Password.Length < 6)
                    throw new Exception("La nueva contraseña debe tener al menos 6 caracteres");
                adminExistente.Password = administrador.Password;
            }

            await _context.SaveChangesAsync();

            return adminExistente;
        }

        // 🗑️ ELIMINAR ADMINISTRADOR
        public async Task<bool> DeleteAdministrador(string id)
        {
            var admin = await _context.Administradores.FindAsync(id);

            if (admin == null)
                return false;

            // 🔹 Verificar si el administrador tiene productos asignados antes de eliminar
            var tieneProductosAsignados = await _context.Productos
                .AnyAsync(p => p.IdAdmin == id);

            if (tieneProductosAsignados)
                throw new Exception("No se puede eliminar el administrador porque tiene productos registrados a su nombre");

            _context.Administradores.Remove(admin);
            await _context.SaveChangesAsync();

            return true;
        }
        }
}
