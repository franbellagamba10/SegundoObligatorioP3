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
            if (string.IsNullOrWhiteSpace(iluminacion) || iluminacion.Length>20) // verificar si corresponde esta validacion
                return false;
            return true;
        }
    }
}
