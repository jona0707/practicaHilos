using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Claims;

namespace PracticaHilos
{
    internal class Practica01g
    {
        //Paso de parámetros a un hilo
        static void Main(string[] args)
        {
            var ejemplo = new HiloEjemplo(10); 
            var hiloUno = new Thread(ejemplo.Contar);

            //Hilo 1
            hiloUno.Name = "hilo Primero";
            hiloUno.Start(); 
            hiloUno.Join();
            Console.WriteLine("------"); 

            //Hilo 2
            var hiloDos = new Thread(Contar);
            hiloDos.Name = "hilo Dos";
            hiloDos.Start(8); 
            hiloDos.Join(); 
            Console.WriteLine("------");

            //Hilo 3
            var hiloTres = new Thread(() => ContarNumeros(12));
            hiloTres.Name = "hilo Tres"; hiloTres.Start();
            hiloTres.Join();
            Console.WriteLine("------");

            //Hilo 4 y 5
            int i = 10;
            var hiloCuatro = new Thread(() => ImprimirNumeros(i)); 
            i = 20;
            var hiloCinco = new Thread(() => ImprimirNumeros(i));
            hiloCuatro.Start(); 
            hiloCinco.Start();
        }
        static void ImprimirNumeros(int numero)
        {
            Console.WriteLine(numero);
        }
        class HiloEjemplo
        {
            private readonly int numIteraciones;
            //Métodos para la creació
            public HiloEjemplo(int iteraciones)
            {
                numIteraciones = iteraciones;
            }
            public void Contar()
            {
                for (int i = 0; i < numIteraciones; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));

                    Console.WriteLine("{0} imprime {1}", Thread.CurrentThread.Name.ToString(), i);
                }
            }

        }
        static void Contar(object iteraciones)
        {
            ContarNumeros((int)iteraciones);
        }
        static void ContarNumeros(int iteraciones)
        {
            for (int i = 1; i <= iteraciones; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} imprime {1} ", Thread.CurrentThread.Name, i);
            }
        }
    }
}
