using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fachada
{
    public interface IManejadorPlantas
    {
        #region Plantas
        bool AgregarNuevaPlanta(Planta planta);
        bool DarDeBajaPlanta(int id);
        IEnumerable<Planta> ObtenerTodasLasPlantas();
        Planta ObtenerPlantaPorNombreCientifico(string nombreCientifico);
        bool ActualizarPlanta(Planta planta);
        Planta ObtenerPlantaPorId(int id);
        IEnumerable<Planta> BusquedaPlantas(string nombre, TipoPlanta tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente);
        #endregion

        #region Ficha
        IEnumerable<Ficha> ObtenerTodasLasFichas();
        Ficha ObtenerFichaPorId(int id);
        IEnumerable<TipoIluminacion> ObtenerTodosLosTI();
        IEnumerable<FrecuenciaRiego> ObtenerTodasLasFR();
        public bool AgregarNuevaFicha(Ficha ficha);
        TipoIluminacion ObtenerTIPorId(int id);
        FrecuenciaRiego ObtenerFRPorId(int id);
        #endregion

        #region TipoPlanta
        IEnumerable<TipoPlanta> TraerTodosLosTiposDePlanta();
        TipoPlanta ObtenerTipoPlantaPorId(int id);
        bool DarDeBajaTipoPlanta(int id);
        bool ActualizarTipoPlanta(TipoPlanta tipoPlanta);
        public bool AgregarNuevoTipoPlanta(TipoPlanta tipoPlanta);
        TipoPlanta ObtenerTipoPlantaPorNombre(string nombreTP);
        
        #endregion

        
        
        
    }
}