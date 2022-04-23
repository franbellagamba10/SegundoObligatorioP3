using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class PlantaDTO
    {
        public int id { get; set; }
        public TipoPlanta tipo { get; set; }
        public string nombreCientifico { get; set; }
        public string nombresVulgares { get; set; }
        public string descripcion { get; set; }
        public Ambiente ambiente { get; set; }
        public int alturaMaxima { get; set; }
        public string foto { get; set; }
        public decimal precio { get; set; }
        public Usuario ingresadoPor { get; set; }
        public Ficha ficha { get; set; }
        public IEnumerable<TipoPlanta> TiposPlanta { get; set; }

        public enum Ambiente
        {
            Exterior,
            Interior,
            Mixta
        }
    }
}
