using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaHilos
{
    internal class Practica01c
    {
        //Consiguiendo que un hilo espere
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando");
            Thread hiloTrabajador = new Thread(ImprimirNumerosConRetardo);
            hiloTrabajador.Start(); 
            //Uso de Join para limitar las interrupciones.
            //hiloTrabajador.Join();
            Console.WriteLine("Ejecución de hilo principal finalizada");
        }
        static void
        ImprimirNumerosConRetardo()
        {
            Console.WriteLine("Empezando ....");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
            Console.WriteLine("Hilo trabajador por concluir");
        }

    }
}
