using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
