using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Fachada
{
    public class ManejadorPlantas : IManejadorPlantas
    {

        public IRepositorioPlantas RepoPlantas { get; set; }
        public IRepositorio<TipoPlanta> RepoTP { get; set; }
        public IRepositorio<FrecuenciaRiego> RepoFR { get; set; }
        public IRepositorio<TipoIluminacion> RepoTI { get; set; }
        public IRepositorio<Ficha> RepoFichas { get; set; }
        public ManejadorPlantas(IRepositorioPlantas repoPlanta, IRepositorio<FrecuenciaRiego> repoFrecRiego, IRepositorio<TipoIluminacion> repoTipoIlu, IRepositorio<Ficha> repoFichas, IRepositorio<TipoPlanta> repoTP)
        {
            RepoPlantas = repoPlanta;
            RepoFR = repoFrecRiego;
            RepoTI = repoTipoIlu;
            RepoFichas = repoFichas;
            RepoTP = repoTP;
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

        public Planta ObtenerPlantaPorId(int id)
        {
            return RepoPlantas.FindById(id);
        }

        public IEnumerable<TipoPlanta> TraerTodosLosTiposDePlanta()
        {
            return RepoTP.GetAll();
        }

        public IEnumerable<Ficha> TraerTodasLasFichas()
        {
            return RepoFichas.GetAll();
        }

        public bool ActualizarPlanta(Planta planta)
        {
            return RepoPlantas.Update(planta);
        }

        public Ficha ObtenerFichaPorId(int id)
        {
            return RepoFichas.FindById(id);
        }

        public TipoPlanta ObtenerTipoPlantaPorId(int id)
        {
            return RepoTP.FindById(id);
        }

        public Planta ObtenerPlantaPorNombreCientifico(string nombreCientifico)
        {
            return RepoPlantas.FindByName(nombreCientifico);
        }

        public bool ActualizarTipoPlanta(TipoPlanta tipoPlanta)
        {
            return RepoTP.Update(tipoPlanta);
        }
        public bool AgregarNuevoTipoPlanta(TipoPlanta tipoPlanta)
        {
            return RepoTP.Create(tipoPlanta);
        }

        public TipoPlanta ObtenerTipoPlantaPorNombre(string nombreTP)
        {
            return RepoTP.FindByName(nombreTP);
        }

        public bool DarDeBajaTipoPlanta(int id)
        {
            return RepoTP.Delete(id);
        }

        public IEnumerable<Planta> BusquedaPlantas(string nombre, int tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente)
        {
            return RepoPlantas.QuerySearch(nombre, tipoPlanta, alturaMaximaDesde, alturaMaximaHasta, ambiente);
        }
    }
}