using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Planta
    {
        public int id { get; set; }
        public TipoPlanta tipo { get; set; }
        public string nombreCientifico { get; set; }
        public string nombresVulgares { get; set; }
        public string descripcion { get; set; }
        public string ambiente { get; set; }
        public int alturaMaxima { get; set; }
        public string foto { get; set; }
        public double precio { get; set; }
        public Usuario ingresadoPor { get; set; }
    }
}
