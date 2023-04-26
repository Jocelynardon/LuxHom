using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxHomModel
{
    public class Usuario
    {
        public string Usuario1 { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? FechaTransac { get; set; }

        public string? UsuarioElimina { get; set; }

        public DateTime? FechaTransacElimina { get; set; }

        public sbyte Vigente { get; set; }
    }
}
