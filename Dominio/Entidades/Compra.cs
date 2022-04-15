using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public abstract class Compra
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public List<String> lineas { get; set; }
        public abstract double GetTotal();
    }
}
