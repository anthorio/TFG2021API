using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class FacturaRequest
    {
        public int FacturaID { get; set; }
        public int Pedido_Factura { get; set; }
        public string InfoPedido { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IVA { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
