using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Item
    {
        public Planta planta { get; set; }
        public Compra compra { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnidad { get; set; }
                
        public double GetSubTotal()
        {
            double subtotal = 0;            
            return subtotal;
        }        
    }
}
