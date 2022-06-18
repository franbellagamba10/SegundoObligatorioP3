using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Dominio.Entidades
{

    public class Item
    {

        public Planta Planta { get; set; }
        [Key]
        [Required]
        public int PlantaId { get; set; }

        public Compra Compra{get;set;}
        [Key]
        [Required]
        public int CompraId { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int cantidad { get; set; }

        [Required]
        [Range(1, (double)decimal.MaxValue)]
        public decimal precioUnidad { get; set; }
                
        public double GetSubTotal()
        {
            double subtotal = (double)Planta.precio * cantidad;           
            return subtotal;
        }        
    }
}
