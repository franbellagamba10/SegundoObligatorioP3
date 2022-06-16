using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Dominio.Interfaces;


namespace Dominio.Entidades
{
    [Table("Fichas")]
    public class Ficha
    {
        [Key]
        public int id { get; set; }

        [Required]
        public FrecuenciaRiego frecuenciaRiego { get; set; }
        public int frecuenciaRiegoId { get; set; }
        [Required]
        public TipoIluminacion tipoIluminacion { get; set; }
        public int tipoIluminacionId { get; set; }
        [Required]
        public decimal temperatura { get; set; }
        public IEnumerable<Planta>Plantas {get; set;} 
        public Ficha()
        {

        }        
    }
}