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

            #region Test unitario para YaExisteString(string)
            if (repoTipos.YaExisteString("una plantita"))
                Console.WriteLine("Si existe");
            else
                Console.WriteLine("NO existe");
            Console.WriteLine("-----------------------");
            if (repoTipos.YaExisteString("plantita"))
                Console.WriteLine("Si existe");
            else
                Console.WriteLine("NO existe");
            #endregion


            //TipoPlanta tipo = new TipoPlanta()
            //{
            //    nombre = "una plantita",
            //    descripcion = "es roja y crece dos metros",
            //};
            //repoTipos.Create(tipo);


            //Usuario user1 = new Usuario()
            //{
            //    email = "otroBIEN@gmail.com",
            //    contrasenia = "contraBIEN22",
            //};
            //repoUsuarios.Create(user1);

            //Usuario user2 = new Usuario()
            //{
            //    email = "otromal@gmail.com",
            //    contrasenia = "contramal22",
            //};
            //repoUsuarios.Create(user2);



            //Planta faso = new Planta()
            //{
            //    tipo = repoTipos.FindById(1),
            //    nombreCientifico = "ayahuasca",
            //    nombresVulgares = "la que bajo las torres gemelas",
            //    descripcion = "404",
            //    ambiente = (Planta.Ambiente)0,
            //    alturaMaxima = 300,
            //    foto = "una_Foto2.jpg",
            //    precio = 300,
            //    ingresadoPor = repoUsuarios.FindById(1),
            //};
            //repoPlantas.Create(faso);

            //bool encontreUsuario = repoUsuarios.ExisteMail("otroBIEN22@gmail");

            //bool noEncontreUser = repoUsuarios.ExisteMail("cualquiera");

            //Console.WriteLine("Encontre: " + encontreUsuario);
            //Console.WriteLine("No encontre: " + noEncontreUser);
            //Console.ReadKey();
        }
    }
}
