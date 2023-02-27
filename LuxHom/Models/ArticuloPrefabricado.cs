using System;
using System.Collections.Generic;

namespace LuxHom.Models;

public partial class ArticuloPrefabricado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public decimal Precio { get; set; }
}
