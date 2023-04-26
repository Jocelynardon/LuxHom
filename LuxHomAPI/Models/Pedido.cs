using System;
using System.Collections.Generic;

namespace LuxHomAPI.Models;

public partial class Pedido
{
    public int Correlativo { get; set; }

    public int PersonaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public DateTime? FechaPedido { get; set; }

    //public virtual Persona Persona { get; set; } = null!;

    //public virtual Producto Producto { get; set; } = null!;
}
