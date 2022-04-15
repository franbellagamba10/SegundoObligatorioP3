using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejecutable
{
    public interface IManejadorUsuarios
    {
        bool AgregarNuevoUsuario(Usuario usuario);

        bool DarDeBajaUsuario(int id);
    }
}
