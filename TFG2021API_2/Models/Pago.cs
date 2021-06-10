using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Pago
    {
        public int PagoId { get; set; }
        public int FacturaPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Observaciones { get; set; }

        public virtual Factura FacturaPagoNavigation { get; set; }
    }
}
