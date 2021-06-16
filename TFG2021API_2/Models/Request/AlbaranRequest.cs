using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class AlbaranRequest
    {
        public int AlbaranID { get; set; }
        public int Pedido_Albaran { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
