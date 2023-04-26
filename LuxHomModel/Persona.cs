using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxHomModel
{
    public class Persona
    {
        public int Id { get; set; }

        public string Usuario { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string? Genero { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }
    }
}
