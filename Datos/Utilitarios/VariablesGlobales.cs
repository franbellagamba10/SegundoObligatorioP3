using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Datos.Utilitarios
{
    public class VariablesGlobales
    {
        public ViveroContext db { get; set; }
        //public int LargoMaximoDescripcion { get; set; } //revisar si aplican
        //public int LargoMinimoDescripcion { get; set; } //revisar
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
        public decimal IVA { get; set; }
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
        public decimal ImpuestoImportacion { get; set; }
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
        public decimal TasaArancelaria { get; set; }

        VariablesGlobales(ViveroContext ctx)
        {
            db = ctx;
            IVA = ObtenerIVA();
            ImpuestoImportacion = ObtenerImpuestoImportacion();
            TasaArancelaria = ObtenerTasaArancelaria();
        }
        public decimal ObtenerIVA()
        {
            decimal IVA = db.VariablesGlobales.Select(x => x.IVA).SingleOrDefault();
            if (IVA == 0)
                IVA = (decimal)22.55;

            return IVA;
        }
        public decimal ObtenerImpuestoImportacion()
        {
            decimal impImport = db.VariablesGlobales.Select(x => x.ImpuestoImportacion).SingleOrDefault();
            if (impImport == 0)
                impImport = (decimal)10;

            return impImport;
        }
        public decimal ObtenerTasaArancelaria()
        {
            decimal tasaArancelaria = db.VariablesGlobales.Select(x => x.TasaArancelaria).SingleOrDefault();
            if (tasaArancelaria == 0)
                tasaArancelaria = (decimal)6;

            return tasaArancelaria;
        }
    }
}
