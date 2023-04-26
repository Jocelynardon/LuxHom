using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxHomModel
{
    public class Publicacion
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Contenido { get; set; }

        public string Autor { get; set; } = null!;

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}
