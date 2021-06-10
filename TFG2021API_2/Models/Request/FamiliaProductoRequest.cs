using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class FamiliaProductoRequest
    {
        public int FamiliaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
