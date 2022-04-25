using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IRepositorioPlantas : IRepositorio<Planta>
    {
        public string ObtenerNombreFoto(string nombrePlanta);
        
        public Planta BuscarPlantaPorNombreCientifico(string nombreCientifico);
    }
}
