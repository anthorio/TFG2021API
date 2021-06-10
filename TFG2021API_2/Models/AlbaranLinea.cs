using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class AlbaranLinea
    {
        public int LineaAlbaranId { get; set; }
        public int AlabaranAlbaranLinea { get; set; }
        public int? PedidoLineaAlbaranLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }

        public virtual Albaran AlabaranAlbaranLineaNavigation { get; set; }
        public virtual PedidoLinea PedidoLineaAlbaranLineaNavigation { get; set; }
    }
}
