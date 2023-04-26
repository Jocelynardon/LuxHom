using System;
using System.Collections.Generic;

namespace LuxHomAPI.Models;

public partial class Usuario
{
    public string Usuario1 { get; set; } = null!;

    public string Email { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? FechaTransac { get; set; }

    public string? UsuarioElimina { get; set; }

    public DateTime? FechaTransacElimina { get; set; }

    public sbyte Vigente { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
