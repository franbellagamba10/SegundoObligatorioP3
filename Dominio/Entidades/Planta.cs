using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Planta
    {
        private TipoPlanta tipo { get; set; }
        private string nombreCientifico { get; set; }
        private string nombresVulgares { get; set; }
        private string descripcion { get; set; }
        private string ambiente { get; set; }
        private int alturaMaxima { get; set; }
        private string foto { get; set; }
        private double precio { get; set; }
        private int id { get; set; }
        private Usuario ingresadoPor { get; set; }
    }
}
