using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioUsuariosADO : IRepositorioUsuarios
    {
        public bool Create(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }   

        public bool Validar(Usuario obj)
        {


            return true;
        }
    }
}
