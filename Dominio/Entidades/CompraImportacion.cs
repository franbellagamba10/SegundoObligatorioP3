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

        public override decimal CalcularTotal(decimal impuestoImportacion, decimal tasaArancelaria)
        {
            decimal total = 0;
            foreach (var item in base.Items)
                total += item.precioUnidad * item.cantidad;
 
            decimal precioTasaArancelaria = total * (tasaArancelaria / 100);
            total += precioTasaArancelaria;

            total += impuestoImportacion;
            
            return total;
        }
    }        
}
