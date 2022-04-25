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
        #endregion

        #region Ficha
        IEnumerable<Ficha> TraerTodasLasFichas();
        Ficha ObtenerFichaPorId(int id);
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