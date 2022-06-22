using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ViveroDTOs
{
    public class CompraDTO
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public List<Item> Items { get; set; }
        public decimal impuestoImportacion { get; set; }
        public bool esSudamericana { get; set; }
        public decimal tasaArancelaria { get; set; }
        public string medidasSanitarias { get; set; }
        public decimal IVA { get; set; }
        public bool cobroFlete { get; set; }
        public decimal costoEnvio { get; set; }
        public decimal costoTotal { get; set; }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.precioUnidad * item.cantidad;

            var precioIVA = total * (IVA / 100);
            var precioTasaRancelaria = total * (tasaArancelaria / 100);
            total += precioIVA;
            total += costoEnvio;
            total += impuestoImportacion;

            return total;
        }
        public string ObtenerNombresCientificosYCantidades()
        {
            string nombresCientificos = "";

            foreach (Item item in Items)
            {
                nombresCientificos += item.Planta.nombreCientifico + $" ({item.cantidad}) - ";
            }
            nombresCientificos = nombresCientificos.Remove(nombresCientificos.LastIndexOf(" -"));

            return nombresCientificos;
        }
    }
}