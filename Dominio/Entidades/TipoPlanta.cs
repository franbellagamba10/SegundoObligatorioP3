using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio.Entidades
{
    public class TipoPlanta
    {
        [Key]
        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre admite únicamente letras")]
        [Display(Name = "Tipo de planta")]
        public string nombre { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "La descripción debe tener entre {2} y {0} caracteres.", MinimumLength = 10)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        //public List<Planta> Plantas { get; set; } 
        public TipoPlanta()
        {
            
        }        
    }
}
