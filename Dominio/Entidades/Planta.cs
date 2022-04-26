using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public class Planta : IValidate
    {
        public int id { get; set; }
        [Display(Name = "Tipo de Planta")]
        public TipoPlanta tipo { get; set; }
        [Display(Name = "Nombre científico")]
        public string nombreCientifico { get; set; }
        [Display(Name = "Nombres vulgares")]
        public string nombresVulgares { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name = "Ambiente")]
        public Ambiente ambiente { get; set; }
        [Display(Name = "Altura máxima (cm)")]
        public int alturaMaxima { get; set; }
        [Display(Name = "Foto")]
        public string foto { get; set; }
        [Display(Name = "Precio (UYU)")]
        public decimal precio { get; set; }
        [Display(Name = "Usuario autor")]
        public Usuario ingresadoPor { get; set; }
        [Display(Name = "Ficha")]
        public Ficha ficha { get; set; }

        public Planta()
        {
            
        }
        public enum Ambiente
        {
            Exterior = 1,
            Interior,
            Mixta
        }
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(nombreCientifico) || string.IsNullOrWhiteSpace(nombresVulgares)
                || string.IsNullOrWhiteSpace(descripcion) || descripcion.Length > 500 || precio < 1 || !ValidarEnum((int)ambiente)
                || alturaMaxima < 1)
                return false;
            return true;
        }

        public bool ValidarEnum(int valorEnum)
        {
            bool existe = Enum.IsDefined(typeof(Ambiente), valorEnum);
            if (existe)
                return true;

            return false;
        }


    }
}