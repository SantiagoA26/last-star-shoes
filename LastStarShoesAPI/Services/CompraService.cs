using LastStarShoesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LastStarShoesAPI.Services
{
    public class CompraService: ICompraService
    {
        private readonly LaststarShoesDbContext _context;

        public CompraService(LaststarShoesDbContext context)
        {
            _context = context;
        }

        public async Task<Compra> RegistrarCompra(Compra compra)
        {
            decimal totalFactura = 0;

            foreach (var detalle in compra.DetalleCompras)
            {
                // EF buscará por string automáticamente porque id_producto es nvarchar(40)
                var producto = await _context.Productos.FindAsync(detalle.IdProducto);

                if (producto == null)
                    throw new Exception($"El producto {detalle.IdProducto} no existe.");

                if (producto.Stock < detalle.Cantidad)
                    throw new Exception($"No hay stock para {producto.Nombre}.");

                detalle.PrecioUnitario = producto.Precio;
                detalle.Subtotal = detalle.Cantidad * producto.Precio;
                totalFactura += detalle.Subtotal;

                producto.Stock -= detalle.Cantidad;
            }

            compra.Total = totalFactura;
            compra.Fecha = DateTime.Now;

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task<IEnumerable<Compra>> ObtenerHistorial()
        {
            return await _context.Compras.Include(c => c.DetalleCompras).ToListAsync();
        }

        public async Task<Compra?> ObtenerCompraPorId(int id)
        {
            return await _context.Compras
                .Include(c => c.DetalleCompras)
                .FirstOrDefaultAsync(c => c.IdCompra == id);
        }

        public async Task<IEnumerable<Compra>> ObtenerComprasPorCliente(string idCliente)
        {
            return await _context.Compras
                .Where(c => c.IdCliente == idCliente)
                .Include(c => c.DetalleCompras)
                .ToListAsync();
        }
    }
}
