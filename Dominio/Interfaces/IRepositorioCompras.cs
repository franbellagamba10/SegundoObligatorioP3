using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioCompras : IRepositorio<Compra>
    {
        public IEnumerable<Compra> FindByTipoPlanta(int idTP);
    }
}
