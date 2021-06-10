using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class FamiliaProducto
    {
        public FamiliaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int FamiliaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
