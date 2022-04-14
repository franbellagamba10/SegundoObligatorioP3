using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public abstract class Compra
    {
        private int id { get; set; }
        private DateTime fecha { get; set; }
        private List<String> lineas { get; set; }
        public abstract double GetTotal();
    }
}
