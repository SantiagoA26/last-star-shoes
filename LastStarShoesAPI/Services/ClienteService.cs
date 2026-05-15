using LastStarShoesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LastStarShoesAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LaststarShoesDbContext _context;

        public ClienteService(LaststarShoesDbContext context)
        {
            _context = context;
        }

  
        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            // 🔹 Validaciones básicas
            if (string.IsNullOrWhiteSpace(cliente.IdCliente))
                throw new Exception("La cédula es obligatoria");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new Exception("El email es obligatorio");

            if (!cliente.Email.Contains("@"))
                throw new Exception("Email inválido");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new Exception("El teléfono es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Direccion))
                throw new Exception("La dirección es obligatoria");

            if (string.IsNullOrWhiteSpace(cliente.PasswordCliente))
                throw new Exception("La contraseña es obligatoria");

            var existeCliente = await _context.Clientes
                .AnyAsync(c => c.IdCliente == cliente.IdCliente);

            if (existeCliente)
                throw new Exception("El cliente ya existe");

            
            var existeEmail = await _context.Clientes
                .AnyAsync(c => c.Email == cliente.Email);

            if (existeEmail)
                throw new Exception("El email ya está registrado");

            
            cliente.FechaRegistro = DateTime.Now;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

    
        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }


        public async Task<Cliente> GetClienteById(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            return cliente;
        }

  
        public async Task<Cliente> UpdateCliente(string id, Cliente cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente == null)
                throw new Exception("Cliente no encontrado");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new Exception("El email es obligatorio");

            if (!cliente.Email.Contains("@"))
                throw new Exception("Email inválido");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new Exception("El teléfono es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Direccion))
                throw new Exception("La dirección es obligatoria");

   
            if (string.IsNullOrWhiteSpace(cliente.PasswordCliente))
                throw new Exception("La contraseña es obligatoria");

      
            var emailExiste = await _context.Clientes
                .AnyAsync(c => c.Email == cliente.Email && c.IdCliente != id);

            if (emailExiste)
                throw new Exception("El email ya está en uso");


            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.PasswordCliente = cliente.PasswordCliente; 

            await _context.SaveChangesAsync();

            return clienteExistente;
        }

        public async Task<bool> DeleteCliente(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return false;

            var tieneCompras = await _context.Compras
                .AnyAsync(c => c.IdCliente == id);

            if (tieneCompras)
                throw new Exception("No se puede eliminar el cliente porque tiene compras registradas");

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}