using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public class Item
    {
        [Required]
        public Planta planta { get; set; }

        [Required]
        public Compra compra { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int cantidad { get; set; }

        [Required]
        [Range(1, (double)decimal.MaxValue)]
        public decimal precioUnidad { get; set; }
                
        public double GetSubTotal()
        {
            double subtotal = 0;            
            return subtotal;
        }        
    }
}
