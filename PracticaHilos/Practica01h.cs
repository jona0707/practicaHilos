using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;

namespace PracticaHilos
{
    //Bloqueo con lock
    public class Practica01h
    {
        static void Main(string[] args)
        {
            //Se crea un contador:
            var c = new Contador(); 

            //Creación de hilos con ingreso de Contador sin bloqueo
            var t1 = new Thread(() => Prueba(c)); 
            var t2 = new Thread(() => Prueba(c)); 
            var t3 = new Thread(() => Prueba(c)); 
            
            //Inicio y limitación de la interrupción de los hilos
            t1.Start();
            t2.Start(); 
            t3.Start(); 
            t1.Join(); 
            t2.Join();
            t3.Join();

            Console.WriteLine("Cuenta Total: {0}", c.Contar);
            Console.WriteLine("------");
            Console.WriteLine("Contador correcto");

            //Creación de tres hilos con Contador con bloqueo
            var c1 = new ContadorConBloqueo(); 
            t1 = new Thread(() => Prueba(c1)); 
            t2 = new Thread(() => Prueba(c1)); 
            t3 = new Thread(() => Prueba(c1));

            //Inicio y limitación de la interrupción de los hilos
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Cuenta Total: {0}", c1.Contar);
            Console.WriteLine("------");
        }
        static void Prueba(ContadorBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Incrementar(); 
                c.Decrementar();
            }
        }
        class Contador : ContadorBase
        {
            public int Contar { get; private set; }
            public override void Incrementar() { Contar++; }
            public override void Decrementar() { Contar--; }
        }
        class ContadorConBloqueo : ContadorBase
        {
            private readonly object objetoSincronizador = new Object();
            public int Contar { get; private set; }
            public override void Incrementar()
            {
                lock (objetoSincronizador)
                {
                    Contar++; 
                }
            }
            public override void Decrementar()
            { 
                lock(objetoSincronizador)
                {
                    Contar--;
                }
            }
        }
        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        } 

    }
}
