using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{

    public class Item
    {

        public Planta Planta { get; set; }
        [Key]
        [Required]
        public int PlantaId { get; set; }
        [Key]
        [Required]
        public int CompraId { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int cantidad { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal precioUnidad { get; set; }


        Item()
        {

        }

        public decimal GetSubTotal()
        {
            decimal subtotal = precioUnidad * cantidad;
            return subtotal;
        }
    }
}
