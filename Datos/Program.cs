using Dominio.Entidades;
using Dominio.Interfaces;
using System;

namespace Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RepositorioTiposPlantaADO repoTipos = new RepositorioTiposPlantaADO();

            TipoPlanta tipo = new TipoPlanta()
            {
                nombre = "una plantita",
                descripcion = "es roja y crece dos metros",
            };

            repoTipos.Create(tipo);



        }
    }
}