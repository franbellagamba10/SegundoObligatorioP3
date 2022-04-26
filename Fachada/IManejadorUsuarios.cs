using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fachada
{
    public interface IManejadorUsuarios
    {
        bool AgregarNuevoUsuario(Usuario usuario);
        bool DarDeBajaUsuario(int id);
        public Usuario BuscarUsuarioPorSuEmail(string email);
        public bool ActualizarUsuario(Usuario user);                
    }
}