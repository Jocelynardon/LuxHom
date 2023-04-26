using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxHomModel
{
    public class Pedido
    {
        public int Correlativo { get; set; }

        public int PersonaId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public DateTime? FechaPedido { get; set; }
    }
}
