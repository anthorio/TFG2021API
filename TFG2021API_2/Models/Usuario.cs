using System;
using System.Collections.Generic;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Carritos = new HashSet<Carrito>();
            Clientes = new HashSet<Cliente>();
            Pedidos = new HashSet<Pedido>();
        }

        public int UsuarioId { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string CodigoPostal { get; set; }
        public byte? Borrado { get; set; }

        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
