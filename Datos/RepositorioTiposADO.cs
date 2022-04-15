using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    class RepositorioTiposADO : IRepositorio<TipoPlanta>
    {
        public bool Create(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }               

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPlanta FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPlanta> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}
