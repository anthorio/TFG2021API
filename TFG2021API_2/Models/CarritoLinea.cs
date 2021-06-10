using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class CarritoLinea
    {
        public int LineaCarritoId { get; set; }
        public int CarritoCarritoLinea { get; set; }
        public int ProductoCarritoLinea { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito CarritoCarritoLineaNavigation { get; set; }
        public virtual Producto ProductoCarritoLineaNavigation { get; set; }
    }
}
