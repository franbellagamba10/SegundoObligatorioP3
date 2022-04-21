using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Planta : IValidate
    {
        public int id { get; set; }
        public TipoPlanta tipo { get; set; }
        public string nombreCientifico { get; set; }
        public string nombresVulgares { get; set; }
        public string descripcion { get; set; }
        public Ambiente ambiente { get; set; }
        public int alturaMaxima { get; set; }
        public string foto { get; set; }
        public double precio { get; set; }
        public Usuario ingresadoPor { get; set; }
        public Ficha ficha { get; set; }


        public enum Ambiente
        {
            Exterior,
            Interior,
            Mixta
        }
        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(nombreCientifico) || string.IsNullOrWhiteSpace(nombresVulgares)
                || string.IsNullOrWhiteSpace(descripcion) || descripcion.Length > 500|| precio < 1 || string.IsNullOrWhiteSpace(Ambiente)
                || alturaMaxima < 1 )
                return false;
            return true;
        }

        


    }
}
