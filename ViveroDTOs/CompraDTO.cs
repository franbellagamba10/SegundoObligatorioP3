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
    }
}
