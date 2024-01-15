using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaHilos
{
    class Practica01f
    {
        //Hilos en el Foreground y en el Background
        static void Main(string[] args)
        {
            //Creación de hilos con la clase creada
            var hiloForeground = new HiloEjemplo(10);
            var hiloBackground = new HiloEjemplo(20);
            var hiloUno = new Thread(hiloForeground.Contar);
            hiloUno.Name = "hilo Foreground";

            var hiloDos = new Thread(hiloBackground.Contar);

            hiloDos.Name = "hilo Background";
            hiloDos.IsBackground = true;

            hiloUno.Start();
            hiloDos.Start();
        }
        //Creación de clase para crear hilos según un númerodeterminado.
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
    }
} 

  
