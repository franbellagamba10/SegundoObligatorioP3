using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioPlantas : IRepositorio<Planta>
    {
        public string ObtenerNombreFoto(string nombrePlanta);        
        public Planta FindByName(string nombreCientifico);
        public IEnumerable<Planta> QuerySearch(string nombre, int tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente);
    }
}
