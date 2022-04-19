using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public bool activo { get; set; }

        public Usuario()
        {
            activo = true;
        }
    }
}
