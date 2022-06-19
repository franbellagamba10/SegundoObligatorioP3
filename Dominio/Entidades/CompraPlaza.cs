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
            IVA = GetIVA();
        }
        public override double GetTotal()
        {
            double total = 0;

            return total;
        }

        public decimal GetIVA()
        {
            decimal IVA = 0;

            return IVA;
        }
    }
}
