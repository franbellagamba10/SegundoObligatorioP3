﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        public Usuario BuscarUsuarioPorEmail(string mail);
    }
}
