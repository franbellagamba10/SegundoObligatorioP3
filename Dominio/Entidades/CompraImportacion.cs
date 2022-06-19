using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraImportacion : Compra
    {
        [Required]
        public decimal impuestoImportacion { get; set; }
        [Required]
        public bool esSudamericana { get; set; }
        [Required]
        public decimal tasaArancelaria { get; set; }
        public string medidasSanitarias { get; set; }

        public CompraImportacion()
        {

        }
        public override double GetTotal()
        {
            double total = 0;

            return total;
        }
    }        
}
