using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Claims;

namespace PracticaHilos
{
    internal class Practica01j
    {
        //Bloqueo con interlock
        static void Main(string[] args)
        {
            Console.WriteLine("Contador Incorrecto"); 
            //Creación del contador
            var c = new Contador();
            //Procesos con contador
            var t1 = new Thread(() => Prueba(c)); 
            var t2 = new Thread(() => Prueba(c)); 
            var t3 = new Thread(() => Prueba(c));

            //Inicio de los hilos y limitación a interrupciones
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join(); 
            t2.Join();
            t3.Join();
            
            Console.WriteLine("Cuenta Total: {0}", c.Contar);
            Console.WriteLine("------");
            Console.WriteLine("Contador correcto");

            //Creación del contador con bloqueo
            var c1 = new ContadorSinBloqueo(); 
            //Procesos con bloqueador con bloqueo
            t1 = new Thread(() => Prueba(c1)); 
            t2 = new Thread(() => Prueba(c1)); 
            t3 = new Thread(() => Prueba(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join(); t2.Join();
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
            private int contar;
            public int Contar { get { return contar; } }
            public override void Incrementar()
            {
                contar++;
            }
            public override void Decrementar()
            {
                contar--;
            }
        }
        class ContadorSinBloqueo : ContadorBase
        {
            private int contar;
            public int Contar { get { return contar; } }
            public override void Incrementar()
            {
                Interlocked.Increment(ref contar);
            }
            public override void Decrementar()
            {
                Interlocked.Decrement(ref contar);
            }
        }
        abstract class ContadorBase
        {
            public abstract void Incrementar();
            public abstract void Decrementar();
        }
    }
}
