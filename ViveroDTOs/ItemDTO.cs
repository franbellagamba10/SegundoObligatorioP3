using System;
using System.Collections.Generic;
using System.Text;

namespace ViveroDTOs
{
    public class ItemDTO
    {           
        public int PlantaId { get; set; }  
        
        public int CompraId { get; set; }
        
        public int cantidad { get; set; }
        
        public decimal precioUnidad { get; set; }
    }
}
