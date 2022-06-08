using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class FrecuenciaRiego 
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El tiempo debe tener entre {2} y {0} caracteres.", MinimumLength = 1)]
        public string tiempo { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity,ErrorMessage = "Valor ingresado inválido")]
        public int cantidad { get; set; }
        public FrecuenciaRiego()
        {
            
        }        
    }
}