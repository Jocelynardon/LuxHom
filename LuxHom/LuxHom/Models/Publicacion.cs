using System;
using System.Collections.Generic;

namespace LuxHom.Models;

public partial class Publicacion
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Contenido { get; set; }

    public string Autor { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }
}
