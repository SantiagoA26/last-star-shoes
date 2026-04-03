using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

public partial class Administrador
{
    public string IdAdmin { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
