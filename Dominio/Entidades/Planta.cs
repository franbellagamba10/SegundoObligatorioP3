using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Plantas")]
    public class Planta
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Tipo de Planta")]
        public TipoPlanta TipoPlanta { get; set; }
        public int TipoPlantaId { get; set; }

        [Required]
        [Display(Name = "Nombre científico")]
        public string nombreCientifico { get; set; }

        [Required]
        [Display(Name = "Nombres vulgares")]
        public string nombresVulgares { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "La descripción debe tener entre {2} y {0} caracteres.",MinimumLength = 10)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Ambiente")]
        public Ambiente ambiente { get; set; }

        [Required]
        [Display(Name = "Altura máxima (cm)")]
        public int alturaMaxima { get; set; }

        [Display(Name = "Foto")]
        public string foto { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Precio inválido")]
        [Display(Name = "Precio (UYU)")]
        public decimal precio { get; set; }

        [Display(Name = "Usuario autor")]        
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [Required]        
        [Display(Name = "Ficha")]        
        public Ficha Ficha { get; set; }
        public int FichaId { get; set; }

        public List<Item> Items { get; set; }
        public Planta()
        {
            
        }
        public enum Ambiente
        {
            Exterior = 1,
            Interior,
            Mixta
        }        
    }
}