using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades.EntidadesAuxiliares
{
    public class VariablesGlobales
    {
            [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
            public decimal IVA { get; set; }
            [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
            public decimal ImpuestoImportacion { get; set; }
            [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
            public decimal TasaArancelaria { get; set; }
       VariablesGlobales()
       {

       }
    }
}

