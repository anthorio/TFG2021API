using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class AlbaranLineaRequest
    {
        public int LineaAlbaranID { get; set; }
        public int Alabaran_AlbaranLinea { get; set; }
        public int PedidoLinea_AlbaranLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
