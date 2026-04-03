using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

public partial class Producto
{
    public string IdProducto { get; set; } = null!;

    public string? IdAdmin { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Administrador? IdAdminNavigation { get; set; }
}
