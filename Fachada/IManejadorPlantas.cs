using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fachada
{
    public interface IManejadorPlantas
    {
        bool AgregarNuevaPlanta(Planta planta);
        bool DarDeBajaPlanta(int id);
        IEnumerable<Planta> ObtenerTodasLasPlantas();
        bool ActualizarPlanta(Planta planta);
        Planta ObtenerPlantaPorId(int id);
        IEnumerable<TipoPlanta> TraerTodosLosTiposDePlanta();
        TipoPlanta ObtenerTipoPlantaPorId(int id);
        IEnumerable<Ficha> TraerTodasLasFichas();
        Ficha ObtenerFichaPorId(int id);
    }
}