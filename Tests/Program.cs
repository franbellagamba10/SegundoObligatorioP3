﻿using Datos;
using Dominio.Entidades;
using System;

namespace Tests
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

            #region Test unitario para YaExisteString(string) tipoPlanta
            //if (repoTipos.YaExisteString("una plantita"))
            //    Console.WriteLine("Si existe");
            //else
            //    Console.WriteLine("NO existe");
            //Console.WriteLine("-----------------------");
            //if (repoTipos.YaExisteString("plantita"))
            //    Console.WriteLine("Si existe");
            //else
            //    Console.WriteLine("NO existe");
            #endregion



            #region Test unitario para YaExisteString(string) Planta
            //if (repoPlantas.YaExisteString("ayahuasca"))
            //    Console.WriteLine("Si existe");
            //else
            //    Console.WriteLine("NO existe");
            //Console.WriteLine("-----------------------");
            //if (repoPlantas.YaExisteString("plantita"))
            //    Console.WriteLine("Si existe");
            //else
            //    Console.WriteLine("NO existe");
            #endregion


            //TipoPlanta tipo = new TipoPlanta()
            //{
            //    nombre = "pl2antita",
            //    descripcion = "es roja y crece dos metros",
            //};
            //bool valida = tipo.TieneSoloLetras();                                    
            //repoTipos.Create(tipo);


            //Usuario user1 = new Usuario()
            //{
            // email = "otrobien@gmail.com",
            // contrasenia = "contrabien22",
            //};
            //repoUsuarios.Create(user1);



            //Usuario user2 = new Usuario()
            //{
            // email = "otromal@gmail.com",
            // contrasenia = "contramal22",
            //};
            //repoUsuarios.Create(user2);



            //Ficha miFicha = new Ficha();
            //{



            //}



            //Planta faso = new Planta()
            //{
            // tipo = repoTipos.FindById(1),
            // nombreCientifico = "ayahuasca",
            // nombresVulgares = "la que bajo las torres gemelas",
            // descripcion = "404",
            // ambiente = (Planta.Ambiente)0,
            // alturaMaxima = 300,
            // foto = "una_foto2.jpg",
            // precio = 300,
            // ingresadoPor = repoUsuarios.FindById(1),

            //};
            //repoPlantas.Create(faso);

            //bool encontreUsuario = repoUsuarios.ExisteMail("otroBIEN22@gmail");
            //bool noEncontreUser = repoUsuarios.ExisteMail("cualquiera");


            //Console.WriteLine("Encontre: " + encontreUsuario);
            //Console.WriteLine("No encontre: " + noEncontreUser);
            //Console.ReadKey();


            //#region Test unitario para BuscarUsuarioPorMail
            //Console.WriteLine("Validacion correcta (tiene que existir en BD):");
            //Usuario user = repoUsuarios.BuscarUsuarioPorEmail("francesco@ort.edu.uy");
            //Console.WriteLine(user?.ToString());
            //if (user == null)
            //    Console.WriteLine("No hay usuario 1");
            //else
            //    Console.WriteLine("encontre usuario 1");
            //Console.WriteLine("====================================");
            //Console.WriteLine("Validacion incorrecto:");
            //user = repoUsuarios.BuscarUsuarioPorEmail("mail@algo.com");
            //Console.WriteLine(user?.ToString());
            //if (user == null)
            //    Console.WriteLine("No hay usuario 2");
            //else
            //Console.WriteLine("encontre usuario 2");
            //Console.ReadKey();
            //#endregion


            bool resultado = TieneSoloLetras("ñÑ áéíóú ÁÉÍÓÚ");            
            Console.WriteLine(resultado);
            resultado = TieneSoloLetras("aá eé ií oó uú AENBER ");
            Console.WriteLine(resultado);
            Console.ReadKey();
            bool TieneSoloLetras(string nombre)
            {
                int i = 0;
                bool TieneValorAlfabetico = true;
                while (i < nombre.Length)// && TieneValorAlfabetico)
                {
                    var valor = (int)nombre[i];

                   
                    if ((int)nombre[i] >= 65 && (int)nombre[i] <= 90 || (int)nombre[i] >= 97 && (int)nombre[i] <= 122 || (int)nombre[i] >= 160 && (int)nombre[i] <= 165 ||
                    (int)nombre[i] == 130 || (int)nombre[i] == 144 || (int)nombre[i] == 181 || (int)nombre[i] == 214 || (int)nombre[i] == 224 || (int)nombre[i] == 223 || (int)nombre[i] == 32)
                        TieneValorAlfabetico = true;
                    else
                        TieneValorAlfabetico = false;

                    i++;
                }
                return TieneValorAlfabetico;
            }


        }
    }
}