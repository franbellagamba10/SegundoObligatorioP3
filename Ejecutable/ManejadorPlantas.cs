using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejecutable
{
    public class ManejadorPlantas : IManejadorPlantas
    {

        public IRepositorioPlantas RepoPlantas { get; set; }

        public ManejadorPlantas(IRepositorioPlantas repo)
        {
            RepoPlantas = repo;
        }

        public bool AgregarNuevaPlanta(Planta planta)
        {
            return RepoPlantas.Create(planta);
        }

        public bool DarDeBajaPlanta(int id)
        {
            return RepoPlantas.Delete(id);
        }
    }
}
