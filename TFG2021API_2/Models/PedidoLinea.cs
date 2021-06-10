using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class PedidoLinea
    {
        public PedidoLinea()
        {
            AlbaranLineas = new HashSet<AlbaranLinea>();
        }

        public int LineaPedidoId { get; set; }
        public int PedidoPedidoLinea { get; set; }
        public int ProductoPedidoLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }

        public virtual Pedido PedidoPedidoLineaNavigation { get; set; }
        public virtual Producto ProductoPedidoLineaNavigation { get; set; }
        public virtual ICollection<AlbaranLinea> AlbaranLineas { get; set; }
    }
}
