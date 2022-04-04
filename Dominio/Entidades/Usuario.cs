using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario
    {
        private string email { get; set; }
        private string contrasenia { get; set; }
        private bool esActivo { get; set; }
        private int id { get; set; }
    }
}
