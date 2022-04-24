using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class CompraImportacion : Compra
    {
        public static decimal impustoImportacion { get; set; }
        public bool esSudamericana { get; set; }
        public static decimal tasaArancelaria { get; set; }
        public string medidasSanitarias { get; set; }

        public CompraImportacion()
        {
            
        }
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
