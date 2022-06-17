using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Dominio.Entidades
{
    public abstract class Compra
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime fecha { get; set; }

        [Required]
        [MinLength(1)]
        public List<Item> Items { get; set; }


        public abstract double GetTotal();
        public Compra()
        { 

        }        
    }
}
