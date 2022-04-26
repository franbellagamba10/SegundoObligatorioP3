using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioCompras
    {   
        public Item FindByIds(int idPlanta, int idCompra);
        public IEnumerable<Item> FindAllById(int idCompra);
        public IEnumerable<Item> GetAllItems();
    }
}
