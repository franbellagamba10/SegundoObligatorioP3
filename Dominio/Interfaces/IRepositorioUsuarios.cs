using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>, IValidate<Usuario>
    {
        public Usuario Login(string email, string contrasenia)
        {
            Usuario usuario = null;


            //----> EDITAR

            return usuario;
        }

        public void Logout()
        {
            //----> EDITAR
        }

        

        
    }
}
