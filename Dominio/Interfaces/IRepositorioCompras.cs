using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioCompras : IRepositorio<Compra>
    {
        public IEnumerable<Compra> FindByTipoPlanta(int idTP);

        //aca tienen que ir todos los metodos que hacen los calculos antes de agregar la comrpa a la BD
        //y tambien los que obtienen los impuestos
        public decimal CalcularPrecioTotal(Compra compra);

    }
}
