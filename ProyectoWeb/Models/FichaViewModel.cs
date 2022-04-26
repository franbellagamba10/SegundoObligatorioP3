using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class FichaViewModel
    {
        public int id { get; set; }
        public FrecuenciaRiego frecuenciaRiego { get; set; }
        public TipoIluminacion tipoIluminacion { get; set; }
        public decimal temperatura { get; set; }
        public IEnumerable<FrecuenciaRiego> frecuenciasRiego { get; set; }
        public IEnumerable<TipoIluminacion> tiposIluminacion { get; set; }
        public int frecuenciaRiegoSeleccionada { get; set; }
        public int tipoIluminacionSeleccionado { get; set; }
    }
}
