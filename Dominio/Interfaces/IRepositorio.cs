﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorio<T>
    {
        bool Create(T obj);
        bool Delete(int id);
        bool Update(T obj);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindById(int id);

    }
}
