using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class FacturaLineaRequest
    {
        public int LineaFacturaID { get; set; }
        public int Producto_FacturaLinea { get; set; }
        public int Factura_FacturaLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal importe { get; set; }

    }
}
