using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades.EntidadesAuxiliares;

namespace Dominio.Interfaces
{
    public interface IRepositorioCompras : IRepositorio<Compra>
    {
        public IEnumerable<Compra> FindByTipoPlanta(int idTP);
        public decimal CalcularPrecioTotal(Compra compra);
        //public decimal ObtenerIVA();
        //public decimal ObtenerImpuestoImportacion();
        //public decimal ObtenerTasaArancelaria();


        public VariablesGlobales ObtenerVariablesGlobales();

    }
}
