﻿using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class TipoPlanta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }        
    }
}
