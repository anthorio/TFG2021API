using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class PagoRequest
    {
        public int PagoID { get; set; }
        public int Factura_Pago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Observaciones { get; set; }
    }
}
