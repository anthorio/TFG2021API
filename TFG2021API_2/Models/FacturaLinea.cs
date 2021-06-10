using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class FacturaLinea
    {
        public int LineaFacturaId { get; set; }
        public int ProductoFacturaLinea { get; set; }
        public int FacturaFacturaLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }

        public virtual Factura FacturaFacturaLineaNavigation { get; set; }
        public virtual Producto ProductoFacturaLineaNavigation { get; set; }
    }
}
