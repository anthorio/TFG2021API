using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class PedidoLineaRequest
    {
        public int LineaPedidoID { get; set; }
        public int Pedido_PedidoLinea { get; set; }
        public int Producto_PedidoLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }


    }
}
