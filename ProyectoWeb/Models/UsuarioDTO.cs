using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public bool activo { get; set; }
    }
}
