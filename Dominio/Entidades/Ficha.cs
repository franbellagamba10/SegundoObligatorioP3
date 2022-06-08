using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Dominio.Interfaces;


namespace Dominio.Entidades
{
    public class Ficha
    {
        [Key]
        public int id { get; set; }

        [Required]
        public FrecuenciaRiego frecuenciaRiego { get; set; }

        [Required]
        public TipoIluminacion tipoIluminacion { get; set; }

        [Required]
        public decimal temperatura { get; set; }

        public Ficha()
        {

        }        
    }
}