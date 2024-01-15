using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace practica01
{
    internal class Practica01b
    {
        //Pausa de un Hilo
        static void Main(string[] args)
        {
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start();
            ImprimirNumeros();
        }
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ....");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ....");
            for (int i = 1; i < 10; i++)
            {
                //Se agrega un sleep para limitar igual las interrupciones.
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
