using System;
using System.Collections.Generic;

namespace pagos.Models;

public partial class Usuario
{
    public string Idusuario { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
