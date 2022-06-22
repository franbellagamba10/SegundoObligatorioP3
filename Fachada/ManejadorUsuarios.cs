using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fachada
{
    public class ManejadorUsuarios : IManejadorUsuarios
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public ManejadorUsuarios(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public bool AgregarNuevoUsuario(Usuario usuario)
        {
            return RepoUsuarios.Create(usuario);
        }

        public bool DarDeBajaUsuario(int id)
        {
            return RepoUsuarios.Delete(id);
        }

        public Usuario BuscarUsuarioPorSuEmail(string email)
        {
            return RepoUsuarios.FindByName(email);
        }

        public bool ActualizarUsuario(Usuario user)
        {
            return RepoUsuarios.Update(user);
        }
        public List<string> GenerarUsuarios()
        {
            return RepoUsuarios.GenerarUsuarios();
        }
    }
}