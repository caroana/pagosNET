using System;
using System.Collections.Generic;

namespace pagos.Models;

public partial class Comercio
{
    public int CodigoComercio { get; set; }

    public string Nombre { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
