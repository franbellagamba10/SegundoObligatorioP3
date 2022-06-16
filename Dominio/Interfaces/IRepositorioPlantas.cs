using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioPlantas : IRepositorio<Planta>
    {        
        public IEnumerable<Planta> QuerySearch(string nombre, TipoPlanta tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente);
    }
}
