using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Item //es Compra_Planta en la BD
    {
        private Planta planta { get; set; }
        private Compra compra { get; set; }
        private int cantidad { get; set; }

        public double GetSubTotal()
        {
            double subtotal = 0;

            return subtotal;
        }
    }
}
