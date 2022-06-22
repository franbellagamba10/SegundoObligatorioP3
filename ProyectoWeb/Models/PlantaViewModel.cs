using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class PlantaViewModel
    {
        public int id { get; set; }
        [Display(Name = "Tipo de Planta")]
        public TipoPlanta tipo { get; set; }
        [Display(Name = "Nombre Cientifico")]
        public string nombreCientifico { get; set; }
        [Display(Name = "Nombres vulgares")]
        public string nombresVulgares { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La descripción debe tener entre {2} y {0} caracteres.", MinimumLength = 10)]
        public string descripcion { get; set; }
        [Display(Name = "Ambiente")]
        public Ambiente ambiente { get; set; }
        [Display(Name = "Altura máxima (cm)")]
        public int alturaMaxima { get; set; }
        [Display(Name = "Imágen")]
        public string foto { get; set; }
        [Display(Name = "Precio (UYU)")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Precio inválido")]
        public decimal precio { get; set; }
        [Display(Name = "Autor")]
        public Usuario ingresadoPor { get; set; }
        [Display(Name = "Ficha de cuidados")]
        public Ficha ficha { get; set; }
        public IEnumerable<TipoPlanta> TiposPlanta { get; set; }
        public IEnumerable<Ficha> Fichas { get; set; }
        public IEnumerable<Ambiente> Ambientes { get; set; }
        public int IdTipoPlantaSeleccionada { get; set; }        
        public int IdFichaSeleccionada { get; set; }
        public string EmailUsuarioAutor { get; set; }
        public TipoPlanta TipoPlantaSeleccionado { get; set; }
        public Ficha FichaSeleccionada { get; set; }
        public IFormFile imagen { get; set; }
        public enum Ambiente
        {
            Exterior = 1,
            Interior,
            Mixta
        }
    }
}