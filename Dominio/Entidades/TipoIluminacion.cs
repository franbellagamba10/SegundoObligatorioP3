using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public class TipoIluminacion
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "La iluminación debe tener entre {2} y {0} caracteres.", MinimumLength = 1)]
        public string iluminacion { get; set; }

        public TipoIluminacion()
        {
            
        }       
    }
}