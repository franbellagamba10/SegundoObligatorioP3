using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dominio.Entidades
{
    public abstract class Compra : IValidate
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public List<Item> lineas { get; set; }
        public abstract double GetTotal();
        public Compra()
        { }
        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
