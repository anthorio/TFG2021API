using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class ProductoRequest
    {
        public int ProductoID { get; set; }
        public int Familia_Producto { get; set; }
        public int Proveedor_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string URL_imagen { get; set; }
    }
}
