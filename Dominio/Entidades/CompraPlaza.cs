using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraPlaza : Compra
    {
        private decimal IVA { get; set; }
        private bool cobroFlete { get; set; }
        private decimal costoEnvio { get; set; }

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
