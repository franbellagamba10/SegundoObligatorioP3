using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades.EntidadesAuxiliares
{
    public class VariablesGlobales
    {            //public int LargoMaximoDescripcion { get; set; } //revisar si aplican
            //public int LargoMinimoDescripcion { get; set; } //revisar
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

