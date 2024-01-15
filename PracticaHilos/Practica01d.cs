using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaHilos
{
    internal class Practica01d
    {
        //Abortando un hilo

        static void Main(string[] args)
        {
            Console.WriteLine("Empezando el programa");
            //Nuevo hilo
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //Aborto del hilo
            hiloTrabajador.Abort();
            Console.WriteLine("El hilo trabajador ha abortado!");
            Thread hiloTrabajador2 = new Thread(ImprimirNumeros);
            hiloTrabajador2.Start(); ImprimirNumeros();
        }

        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando....");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando....");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(i);
        }
    }
}
