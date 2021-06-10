using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CarritoLineas = new HashSet<CarritoLinea>();
            FacturaLineas = new HashSet<FacturaLinea>();
            PedidoLineas = new HashSet<PedidoLinea>();
        }

        public int ProductoId { get; set; }
        public int FamiliaProducto { get; set; }
        public int ProveedorProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; }

        public virtual FamiliaProducto FamiliaProductoNavigation { get; set; }
        public virtual Proveedor ProveedorProductoNavigation { get; set; }
        public virtual ICollection<CarritoLinea> CarritoLineas { get; set; }
        public virtual ICollection<FacturaLinea> FacturaLineas { get; set; }
        public virtual ICollection<PedidoLinea> PedidoLineas { get; set; }
    }
}
