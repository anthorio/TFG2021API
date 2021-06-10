using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class ClienteRequest
    {
        public int ClienteID { get; set; }
        public int Descuento { get; set; }
        public int UsuarioID_Cliente { get; set; }

    }
}
