using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Fachada
{
    public class ManejadorPlantas : IManejadorPlantas
    {

        public IRepositorioPlantas RepoPlantas { get; set; }
        public IRepositorio<FrecuenciaRiego> RepoFR { get; set; }
        public IRepositorio<TipoIluminacion> RepoTI { get; set; }
        public IRepositorio<Ficha> RepoFichas { get; set; }
        public ManejadorPlantas(IRepositorioPlantas repoPlanta, IRepositorio<FrecuenciaRiego> repoFrecRiego, IRepositorio<TipoIluminacion> repoTipoIlu, IRepositorio<Ficha> repoFichas)
        {
            RepoPlantas = repoPlanta;
            RepoFR = repoFrecRiego;
            RepoTI = repoTipoIlu;
            RepoFichas = repoFichas;
        }

        public bool AgregarNuevaPlanta(Planta planta)
        {
            return RepoPlantas.Create(planta);

        }
        public bool DarDeBajaPlanta(int id)
        {
            return RepoPlantas.Delete(id);
        }

        public IEnumerable<Planta> ObtenerTodasLasPlantas()
        {
            return RepoPlantas.GetAll();
        }
    }
}
