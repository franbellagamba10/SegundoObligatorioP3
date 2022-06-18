using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Fachada
{
    public class ManejadorCompras : IManejadorCompras
    {

        public IRepositorioPlantas RepoPlantas { get; set; }

        public IRepositorioCompras RepoCompras {get;set;} 
       
        public ManejadorCompras(IRepositorioPlantas repoPlanta)
        {
            RepoPlantas = repoPlanta;
        }
               
       

        public IEnumerable<Compra> BuscarComprasPorTipoPlanta(int id)
        {
            throw new NotImplementedException();
        }

        public bool DarDeAlta(Compra compraDatos)
        {
            throw new NotImplementedException();
        }
    }
}