using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Interfaces;

namespace Dominio.Entidades
{
	public class FrecuenciaRiego : IValidate
	{
		public int id { get; set; }
		public string tiempo { get; set; }
		public int cantidad { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(tiempo) || tiempo.Length > 20 || cantidad<=0) // verificar si corresponde esta validacion
                return false;
            return true;
        }
    }
}
