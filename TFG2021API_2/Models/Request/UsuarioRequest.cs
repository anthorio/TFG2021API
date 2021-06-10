using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG2021API_2.Models.Request
{
    public class UsuarioRequest
    {
        public int UsuarioID { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string CodigoPostal { get; set; }
        public byte Borrado { get; set; }

    }
}
