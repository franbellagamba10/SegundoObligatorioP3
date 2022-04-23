using Dominio.Entidades;
using System;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Pruebo el correcto: ");
            Console.WriteLine(Usuario.ValidarEmail("unmail@algo.com"));
            Console.WriteLine(Usuario.ValidarEmail("=========================================="));
            Console.WriteLine("Pruebo el incorrecto: ");
            Console.WriteLine(Usuario.ValidarEmail("@algo.com"));
            Console.WriteLine(Usuario.ValidarEmail("unmail@algocom"));
            Console.WriteLine(Usuario.ValidarEmail("unmail@"));
            Console.WriteLine(Usuario.ValidarEmail("un@mail@algo.com"));
        }
    }
}
