using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Albaran
    {
        public Albaran()
        {
            AlbaranLineas = new HashSet<AlbaranLinea>();
        }

        public int AlbaranId { get; set; }
        public int PedidoAlbaran { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public virtual Pedido PedidoAlbaranNavigation { get; set; }
        public virtual ICollection<AlbaranLinea> AlbaranLineas { get; set; }
    }
}
