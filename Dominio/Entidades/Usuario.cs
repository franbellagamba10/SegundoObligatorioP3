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
    }
}
