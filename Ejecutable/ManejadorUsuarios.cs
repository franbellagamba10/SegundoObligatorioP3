using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejecutable
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
    }
}
