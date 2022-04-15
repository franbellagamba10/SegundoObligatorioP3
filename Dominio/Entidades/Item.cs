using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Item //es Compra_Planta en la BD
    {
        public Planta planta { get; set; }
        public Compra compra { get; set; }
        public int cantidad { get; set; }

        public double GetSubTotal()
        {
            double subtotal = 0;

            return subtotal;
        }
    }
}
