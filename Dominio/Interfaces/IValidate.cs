using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IValidate<T>
    {
        public bool Validar(T obj);
    }
}
