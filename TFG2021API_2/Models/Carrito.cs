using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Carrito
    {
        public Carrito()
        {
            CarritoLineas = new HashSet<CarritoLinea>();
        }

        public int CarritoId { get; set; }
        public int UsuarioCarrito { get; set; }

        public virtual Usuario UsuarioCarritoNavigation { get; set; }
        public virtual ICollection<CarritoLinea> CarritoLineas { get; set; }
    }
}
