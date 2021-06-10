using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public int? Descuento { get; set; }
        public int UsuarioIdCliente { get; set; }

        public virtual Usuario UsuarioIdClienteNavigation { get; set; }
    }
}
