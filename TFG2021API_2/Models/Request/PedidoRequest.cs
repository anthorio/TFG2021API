using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class PedidoRequest
    {
        public int PedidoID { get; set; }
        public int Usuario_Pedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public string TipoEnvio { get; set; }
    }
}
