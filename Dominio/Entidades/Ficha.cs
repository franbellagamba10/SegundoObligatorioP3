using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Ficha
    {
        public int id { get; set; }
        public FrecuenciaRiego frecuenciaRiego { get; set; }
        public TipoIluminacion tipoIluminacion { get; set; }
        public decimal temperatura { get; set; }       
    }
}
