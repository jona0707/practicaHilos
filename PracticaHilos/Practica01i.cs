using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace PracticaHilos
{
    internal class Practica01i
    {
        //Bloqueo con monitor
        static void Main(string[] args)
        {
            object bloqueo1 = new object(); 
            object bloqueo2 = new object();
            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();
            lock (bloqueo2)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Monitor.TryEnter permite no quedarse atascado, retornado falso depuesta de que el timeout ha expirado"); 
                if (Monitor.TryEnter(bloqueo1, TimeSpan.FromSeconds(5)))
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
                else
                {
                    Console.WriteLine("Temporizador no se cumple!");
}
            }
            Console.WriteLine("----");
            new Thread(() => DemasiadosBloqueos(bloqueo1, bloqueo2)).Start();
            lock (bloqueo2)
            {
                Console.WriteLine("Aquí viene una muerte por bloqueo DEADLOCK");
                Thread.Sleep(1000);
                lock (bloqueo1)
                {
                    Console.WriteLine("Desbloqueo del recurso exitoso");
                }
            }
        }
        static void DemasiadosBloqueos(object bloqueo1, object bloqueo2)
        {
            lock (bloqueo1)
            {
                Thread.Sleep(1000);
                lock (bloqueo2) ;
            }
        }
    }

}
