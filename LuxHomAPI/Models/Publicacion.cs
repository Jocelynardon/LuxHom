﻿using System;
using System.Collections.Generic;

namespace LuxHomAPI.Models;

public partial class Publicacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
