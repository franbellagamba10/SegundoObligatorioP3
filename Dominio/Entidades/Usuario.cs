using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public string email { get; set; }
        public string contrasenia { get; set; }
        public bool esActivo { get; set; }
        public int id { get; set; }
    }
}
