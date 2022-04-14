using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraImportacion : Compra
    {
        private static decimal impustoImportacion { get; set; }
        private bool esSudamericana { get; set; }
        private static decimal tasaArancelaria { get; set; }
        private string medidasSanitarias { get; set; }

        public override double GetTotal()
        {
            double total = 0;

            return total;
        }

        public decimal GetPuestoImportacion()
        {
            decimal total = 0;

            return total;
        }

        public decimal GetTasaArancelaria()
        {
            decimal total = 0;

            return total;
        }
    }
}
