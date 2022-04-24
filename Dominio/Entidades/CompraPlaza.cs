using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraPlaza : Compra
    {
        public decimal IVA { get; set; }
        public bool cobroFlete { get; set; }
        public decimal costoEnvio { get; set; }

        public CompraPlaza()
        {
            
        }
        public override double GetTotal()
        {
            double total = 0;

            return total;
        }

        public decimal UpdateIVA()
        {
            decimal IVA = 0;

            return IVA;
        }
    }
}
