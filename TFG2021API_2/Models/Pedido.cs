using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Albarans = new HashSet<Albaran>();
            Facturas = new HashSet<Factura>();
            PedidoLineas = new HashSet<PedidoLinea>();
        }

        public int PedidoId { get; set; }
        public int? UsuarioPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public string TipoEnvio { get; set; }

        public virtual Usuario UsuarioPedidoNavigation { get; set; }
        public virtual ICollection<Albaran> Albarans { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<PedidoLinea> PedidoLineas { get; set; }
    }
}
