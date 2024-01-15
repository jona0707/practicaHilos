using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PracticaHilos
{
    internal class Practica01e
    {
        //Estado de un hilo
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando el programa");
            //Creación de los hilos
            Thread primerHilo = new Thread(ImprimirNumerosConRetardo);
            Thread segundoHilo = new Thread(NoHaceNada);
            Console.WriteLine(primerHilo.ThreadState.ToString());

            //Inicio de los hilos
            primerHilo.Start();
            segundoHilo.Start();

            //Impresión de los estados de los hilos
            for (int i = 1; i < 30; i++)
                Console.WriteLine(primerHilo.ThreadState.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(6));

            primerHilo.Abort();
            Console.WriteLine("El primer hilo ha abortado!");
            Console.WriteLine(primerHilo.ThreadState.ToString()); 
            Console.WriteLine(segundoHilo.ThreadState.ToString());
            Console.ReadLine();
        }
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ….");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 1; i < 10; i++) 
            {
                Thread.Sleep(TimeSpan.FromSeconds(2))
                ; Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }
        static void NoHaceNada()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
