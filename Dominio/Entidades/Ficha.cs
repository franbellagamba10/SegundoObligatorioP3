using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Ficha
    {
        private int id { get; set; }
        private FrecuenciaRiego frecuenciaRiego { get; set; }
        private TipoIluminacion tipoIluminacion { get; set; }
        private decimal temperatura { get; set; }

    }
}
