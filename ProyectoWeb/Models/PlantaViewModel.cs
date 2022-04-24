using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class PlantaViewModel
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
        public IEnumerable<Ficha> Fichas { get; set; }
        public IEnumerable<Ambiente> Ambientes { get; set; }
        public int IdTipoPlantaSeleccionada { get; set; }        
        public int IdFichaSeleccionada { get; set; }
        public string EmailUsuarioAutor { get; set; }
        public TipoPlanta TipoPlantaSeleccionado { get; set; }
        public Ficha FichaSeleccionada { get; set; }
        public enum Ambiente
        {
            Exterior,
            Interior,
            Mixta
        }
    }
}