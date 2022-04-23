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
    }
}
