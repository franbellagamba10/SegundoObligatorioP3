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
        /// | ñ  = 241 |  Ñ = 209 | ú = 250 | Ú = 218 | ó = 243 |Ó = 211 |
        /// í = 237 | Í = 205 | á = 225 | Á = 193 | é = 233 | É = 201 | blank = 32
        /// </summary>
        /// <returns></returns>
        public bool TieneSoloLetras()
        {
            int i = 0;
            bool TieneValorAlfabetico = true;
            while (i < nombre.Length && TieneValorAlfabetico)
            {
                //if (((int)nombre[i] >= 65 && (int)nombre[i] <= 90) || ((int)nombre[i] >= 97 && (int)nombre[i] <= 122) || (int)nombre[i] >= 160 && (int)nombre[i] <= 165 ||
                //(int)nombre[i] == 130 || (int)nombre[i] == 144 || (int)nombre[i] == 181 || (int)nombre[i] == 214 || (int)nombre[i] == 224 || (int)nombre[i] == 223 || (int)nombre[i] == 32)
                if(((int)nombre[i] >= 65 && (int)nombre[i] <= 90) || ((int)nombre[i] >= 97 && (int)nombre[i] <= 122) || (int)nombre[i] == 241 || (int)nombre[i] == 209 || (int)nombre[i] == 225
                    || (int)nombre[i] == 193 || (int)nombre[i] == 233 || (int)nombre[i] == 201 || (int)nombre[i] == 237 || (int)nombre[i] == 205 || (int)nombre[i] == 243 || (int)nombre[i] == 211
                    || (int)nombre[i] == 250 || (int)nombre[i] == 218 || (int)nombre[i] == 32)
                    TieneValorAlfabetico = true;
                else
                   TieneValorAlfabetico = false;                
                i++;
            }
            return TieneValorAlfabetico;
        }
    }
}
