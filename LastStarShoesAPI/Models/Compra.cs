using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string? IdCliente { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string DireccionEnvio { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
