using System;
using System.Collections.Generic;

namespace LuxHom.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
