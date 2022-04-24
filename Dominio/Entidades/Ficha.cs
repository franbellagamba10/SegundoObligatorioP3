using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Interfaces;


namespace Dominio.Entidades
{
    public class Ficha : IValidate
    {
        public int id { get; set; }
        public FrecuenciaRiego frecuenciaRiego { get; set; }
        public TipoIluminacion tipoIluminacion { get; set; }
        public decimal temperatura { get; set; }

        public bool Validar()
        {
            if (temperatura <= 0) // verificar si corresponde esta validacion
                return false;
            return true;
        }
    }
}