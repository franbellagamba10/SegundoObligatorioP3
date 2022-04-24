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
        public List<Item> lineas { get; set; } //En BD guarda un string "1,2,3,4,5,6", se hace .Split(",") y se generan los objetos buscanodo 
        public abstract double GetTotal();
        public Compra()
        { }
        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
