using System;
using System.Collections.Generic;

namespace pagos.Models;

public partial class Transaccione
{
    public int CodigoTransaccion { get; set; }

    public int CodigoComercio { get; set; }

    public string Idusuario { get; set; } = null!;

    public int MedioPago { get; set; }

    public int EstadoTransaccion { get; set; }

    public double Total { get; set; }

    public DateTime Fecha { get; set; }

    public string Concepto { get; set; } = null!;

    public virtual Comercio CodigoComercioNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
