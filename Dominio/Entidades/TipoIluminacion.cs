using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class TipoIluminacion : IValidate
    {
        public int id { get; set; }
        public string iluminacion { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(iluminacion))
                return false;
            return true;
        }
    }
}
