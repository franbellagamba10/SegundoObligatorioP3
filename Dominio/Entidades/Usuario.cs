using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario : IValidate
    {
        public int id { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public bool activo { get; set; }

        public Usuario()
        {
            activo = true;
        }

        public bool Validar()
        {
            if (!ValidarEmail())
                return false;

            int contadorLetras = 0;
            bool tieneMayusculas = false;
            bool tieneMinusculas = false;
            bool tieneNumeros = false;

            if (contrasenia.Length < 6)
                return false;

            while ((!tieneMayusculas || !tieneMinusculas || !tieneNumeros) && !(contadorLetras == contrasenia.Length))
            {
                char letra = Convert.ToChar(contrasenia.Substring(contadorLetras, 1));

                if (Char.IsUpper(letra))
                {
                    tieneMayusculas = true;
                }
                if (Char.IsLower(letra))
                {
                    tieneMinusculas = true;
                }
                if (Char.IsDigit(letra))
                {
                    tieneNumeros = true;
                }
                contadorLetras++;
            }
            if (tieneMayusculas && tieneMinusculas && tieneNumeros)
                return true;
            return false;
        }

        private bool ValidarEmail()
        {
            if (!email.Contains("@"))
                  return false;            
            string[] subCadenas;
            subCadenas = email.Split("@");
            if (!subCadenas[1].Contains(".") || string.IsNullOrWhiteSpace(subCadenas[1]) ||
                string.IsNullOrWhiteSpace(subCadenas[0]) || subCadenas[0].Contains("@") || subCadenas[1].Contains("@"))
                    return false;            
            return true;            
        }
    }
}
