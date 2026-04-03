using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

public partial class DetalleCompra
{
    public int IdFactura { get; set; }

    public int? IdCompra { get; set; }

    public string? IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
