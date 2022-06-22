using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraPlaza : Compra
    {
        [Required]
        public decimal IVA { get; set; }
        [Required]
        public bool cobroFlete { get; set; }
        [Required]        
        public decimal costoEnvio { get; set; }

        public CompraPlaza()
        {

        }

        public override decimal CalcularTotal(decimal Iva, decimal parametroSinuso)
        {
            decimal total = 0;
            foreach (var item in base.Items)
                total += item.GetSubTotal();

            var precioIVA = total * (Iva / 100);
            total += precioIVA;
            total += costoEnvio; 

            return total;
        }
       
    }
}
