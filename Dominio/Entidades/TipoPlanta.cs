using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio.Entidades
{
    public class TipoPlanta : IValidate
    {
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        public TipoPlanta()
        {
            
        }
        public bool Validar()
        {
            if (descripcion.Length < 10 || descripcion.Length > 200 || string.IsNullOrWhiteSpace(descripcion)
                || string.IsNullOrWhiteSpace(nombre) || !TieneSoloLetras())
                return false;
            return true;
        }

        /// <summary>
        /// Valida una cadena de texto segun su codigo ASCII. Si contiene valores representativos distintos a los alfabeticos hispanos devuelve FALSE <br></br>
        /// | ñ  = 164 |  Ñ = 165 | ú = 163 | Ú = 233 | ó = 162 |Ó = 224 |
        /// í = 161 | Í = 214 | á = 160 | Á = 181 | é = 130 | É = 144 |
        /// </summary>
        /// <returns></returns>
        public bool TieneSoloLetras()
        {
            int i = 0;
            bool TieneValorAlfabetico = true;
            while (i < nombre.Length && TieneValorAlfabetico)
            {
                if ((int)nombre[i] >= 65 && (int)nombre[i] <= 90 || (int)nombre[i] >= 97 && (int)nombre[i] <= 122 || (int)nombre[i] >= 160 && (int)nombre[i] <= 165 ||
                (int)nombre[i] == 130 || (int)nombre[i] == 144 || (int)nombre[i] == 181 || (int)nombre[i] == 214 || (int)nombre[i] == 224 || (int)nombre[i] == 223)
                    TieneValorAlfabetico = true;
                else
                   TieneValorAlfabetico = false;                
                i++;
            }
            return TieneValorAlfabetico;
        }
    }
}
