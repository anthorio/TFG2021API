using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaLineas = new HashSet<FacturaLinea>();
            Pagos = new HashSet<Pago>();
        }

        public int FacturaId { get; set; }
        public int PedidoFactura { get; set; }
        public string InfoPedido { get; set; }
        public DateTime FechaFactura { get; set; }
        public int? Iva { get; set; }
        public decimal? Total { get; set; }
        public string Estado { get; set; }

        public virtual Pedido PedidoFacturaNavigation { get; set; }
        public virtual ICollection<FacturaLinea> FacturaLineas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
