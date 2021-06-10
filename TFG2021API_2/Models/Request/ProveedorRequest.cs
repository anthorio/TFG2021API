using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class ProveedorRequest
    {
        public int ProveedorID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
