using System;
using System.Collections.Generic;

namespace LuxHomAPI.Models;

public partial class Usuario
{
    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string PrimerAppelido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string? ApellidoCasada { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Nacionalidad { get; set; }

    public string Email { get; set; } = null!;

    public int? Telefono { get; set; }

    public DateTime FechaNacimiento { get; set; }
}
