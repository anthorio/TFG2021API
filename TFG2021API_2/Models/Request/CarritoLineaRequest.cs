using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class CarritoLineaRequest
    {
        public int LineaCarritoID { get; set; }
        public int Carrito_CarritoLinea { get; set; }
        public int Producto_CarritoLinea { get; set; }
        public int Cantidad { get; set; }

    }
}
