using Datos;
using Dominio.Entidades;
using System;

namespace Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {


            RepositorioTiposPlantaADO repoTipos = new RepositorioTiposPlantaADO();
            RepositorioUsuariosADO repoUsuarios = new RepositorioUsuariosADO();
            RepositorioFrecuenciaRiegoADO repoFR = new RepositorioFrecuenciaRiegoADO();
            RepositorioTipoIluminacionADO repoTI = new RepositorioTipoIluminacionADO();
            RepositorioFichasADO repoFichas = new RepositorioFichasADO(repoFR, repoTI);
            RepositorioPlantasADO repoPlantas = new RepositorioPlantasADO(repoTipos, repoFichas, repoUsuarios);

            //TipoPlanta tipo = new TipoPlanta()
            //{
            //    nombre = "una plantita",
            //    descripcion = "es roja y crece dos metros",
            //};
            //repoTipos.Create(tipo);


            //Usuario user = new Usuario()
            //{
            //    email = "otroMail@gmail.com",
            //    contrasenia = "12345abc",
            //};
            //repoUsuarios.Create(user);

            Planta faso = new Planta()
            {
                tipo = repoTipos.FindById(1),
                nombreCientifico = "ayahuasca",
                nombresVulgares = "la que bajo las torres gemelas",
                descripcion = "404",
                ambiente = "donde puedas",
                alturaMaxima = 300,
                foto = "una_Foto2.jpg",
                precio = 300,
                ingresadoPor = repoUsuarios.FindById(1),
            };
            repoPlantas.Create(faso);
        }
    }
}
