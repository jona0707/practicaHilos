using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace practica01
{
    internal class Practica01a
    {
        static void Main(string[] args)
        {
            // *******************************************************************************
            // Practica 01
            // Sebastian Cruz, Jonathan Puente
            // Fecha de realización: 15/11/2023
            // Fecha de entrega: 22/11/2023
            //
            /*
            1. RESULTADOS:
                Practica01a:
                a. ¿Qué encontró al ejecutar dos veces el programa?
                    Se ejecutó normalmente sin problemas pero si hubo notorias diferencias
                    en las salidas, aún así la base se mantiene y se imprimen los números
                    correspondientes. La segunda vez que se imprimió por ejemplo, se
                    mostraron los números del 1 al 36 y luego volvió imprimió un mensaje
                    de "Empezando..." y contó del 1 al 49 sin haber terminado ell previo.
                    Una vez completó ese ciclo, retorno en donde se quedó previamente (en
                    el 37) y completó hasta el 49.  
                b. ¿Es el resultado el mismo? Explique el por qué
                    En línea con lo previamente mencionado, no fue el mismo resultado, en
                    la primera salida se imprime dos veces el "Empezando..." por lo que se
                    ejecutaron los dos hilos de forma secuencial. En cambio para el segundo,
                    sólo se imprime una vez el "Empezando..." y se imprimen los números del
                    1 al 36.Pero en este punto ya emmpieza el otro hilo por lo que se
                    interrumpen, a diferencia de la primera salida en la que en este punto
                    ya estaban ambos impresos sin interrumpirse.
                c. ¿Qué sucede si cambia la línea ImprimirNúmeros(); antes de la creación 
                    del hilo? 
                    En este caso no hay diferencia entre dos ejecuciones, esto porque la
                    línea "ImprimirNumeros()" realiza todo el trabajo de impresión sin
                    que otro hilo esté tratando de ejecutarse a la vez. Luego, el hilo se
                    ejecuta y al no tener otro proceso también logra completarse sin problemas,
                    quizá pueda que en algún momento el quantum se termine, pero al no
                    haber otros hilos ejecutandose a la vez, no ocurren interrupciones.



                Practica01b:
                a. ¿Qué encontró al ejecutar dos veces el programa?
                    Se encontró que los resultados no fueron los mismos y hubieron difere_
                    cias, sobre todo en el orden de como se imprimieron las salidas. 

                b. ¿Es el resultado el mismo? Explique el por qué
                    No, lo que sucedió en la primera es que se imprió el primer hilo pero 
                    únicamente el comienzo de "Empezando...." y luego entró la impresión
                    donde se completó totalmente la impresión y una vez terminada (hasta 
                    el 9) se retomó la anterior hasta terminarse. En el segundo en cambio
                    se imprimió la primera desde el "Empezando...." hasta el número 9 y 
                    luego de nuevo (es decir, en orden).

                c. ¿Qué diferencia hay con el caso anterior?
                    Principalmente el tiempo de impresión ya que uno de los dos procesos
                    tiene un cierto retardo respecto a la impresión entre números (en el
                    ciclo), esto se logra utilizando el Thread.Sleep que permite la no 
                    interrupción en caso de que otro proceso o hilo quiera interrumpir el 
                    ciclo actual. Es decir que el for no se interrumpirá y se imprimirá
                    del 1 al 9 correctamente gracias a que se duerme el hilo y no prosigue.



                Practica01c:
                a. ¿Qué encontró al ejecutar dos veces el programa?
                    Se encontró una ejecución igual en ambos programas. En ambos se 
                    imprime el "Empezando y a continuación se ejecuta el método que
                    se implementó. Este método se lo llama al crear un hiloTrabajador
                    implementado como un delegado, este será iniciado posteriormente 
                    y luego controlado con el join. Este hilo imprime el texto de 
                    "Empezando...." y también los números del 1 al 9 con el retardo 
                    correspondiente para finalmente imprimir "hilo trabajador por 
                    concluir" cerrando el hilo, para luego imprimir el "Ejecución 
                    de hilo principal finalizada".

                b. ¿Es el resultado el mismo al del código anterior Practica01b?
                    No, no es el mismo porque en primer lugar no se imprimen dos
                    veces los números. Pero ya directamente hablando del for, sí se
                    podría decir que el resultado es el mismo ya que una vez comienza
                    no se corta.

                c. ¿Qué sucede si comenta la línea hiloTrabajador.Join()? ¿Explique 
                   claramente qué sucede en este caso? 
                    Lo que sucede es que pueden existir interrupciones, al comentar
                    el join y ejecutar, el resultado particular fue que se imprimió
                    "Ejecución de hilo principal finalizada" para recién luego iniciar 
                    todo el for y la impresión de números. Entonces, no se limita la 
                    posibilidad de interrumpir, cosa que con el join sí se hace ya 
                    que no se prosigue mientras el hilo haya terminado.



                Practica01d:
                a. Explique claramente qué sucede en este caso. 
                    Este programa empieza imprimiendo el "Empezando el programa" que
                    lo hace en el hilo principal, ya se imprime en consola. Luego se
                    utiliza el delegado y se crea el hilo trabajador para imprimir 
                    los números, sin embargo es inerrumpida luego de imprimir el 1
                    y el 2 y se imprime el mensaje en el hilo principal de que ha 
                    ocurrido un aborto en la operación del hilo trabajador. Esto se
                    lleva a cabo gracias al método Abort() y también a que no se ha
                    limitado el que se pueda interrumpir o no el hilo.

                    Luego simplemente se llevana cabo el resto de los hilos teniendo
                    en cuenta que en caso de no tener limitaciones, podrían ser
                    interrumpidos, sin embargo se llevaron con normalidad y la 
                    impresión se dió correctamente.
   
   

                Practica01e:
                a. Explique claramente qué sucede en este caso. 
                    En este programa se empieza un hilo principal donde se imprime
                    el "Empezando el programa", pero luego se crean un par de hilos
                    donde se utilizan delegados. El primero de estos hace referencia
                    al método de ImprimirNumerosConRetardo() donde se imprimen igual
                    pero además se controla un hilo mendiante un sleep. El segundo
                    en cambio únicamente utiliza un sleep, mas no realiza ninguna
                    otra actividad.
   
                    Al ejecutarse se muestran los estados del primer hilo ya que se
                    tiene un for donde se lo va imprimiendo constantemente una vez
                    ya se haya iniciado tanto el primero como el segundo. El primer
                    hilo en un punto se ve abortado y como en el for sigue imprimiendo
                    en el momento en que se aborta, también se refleja en lo que se
                    imprime. Lo mismo pasa con el segundo hilo donde únicamente se 
                    observa el estado actual de este de forma final.
   


                Practiac01f:
                a. Explique claramente qué sucede en este caso. 
                    Lo que sucede es que se crean dos hilos distintos utilizando la 
                    clase que se ha creado. En este caso se le entrega un parámetro
                    a cada uno, este parámetro entrará como el número de iteraciones
                    que a su vez es atributo que luego entrará en el método contar.
   
                    Se tiene una iteracción hasta el número 9 a pesar de que en el 
                    hilo del Background se tendría en teoría que llegar al 19. Esto
                    sucede porque en el main la ejecución se termina y no se termina
                    mostrando en consola la numeración del hilo background. Este es
                    precisamente el objetivo de un hilo que ocurre en segundo plano.
   
   

                Practica01g:
                a. Explique claramente qué sucede en este caso. 
                    El primer hilo se ejecuta normalmente teniendo en cuenta que se
                    lo crea a través de un delegado y enviando el parámetro de que
                    se cuente hasta antes del 10 (el 9); al tener el Join no se 
                    interrumpe y se termina correctamente el conteo. Luego toca el 
                    segundo hilo donde se inicia directamente en el Start y por ende
                    se imprimen los 8 números del conteo dado el parámetro ingresado,
                    al igual que en el anterior se usa el Join. Finalmente lo que
                    respecta al tercero se realiza lo mismo con operaciones Lamda. 
                    Luego, respecto al hilo 4 y 5 a los que se le entrega el parámetro
                    que está seteado en la variable "i", sin embargo esto no interrumpe
                    el proceso y se imprime correctamente.



                Practica01h:
                a. Explique claramente qué sucede en este caso. 
                    Para este caso se utilizan tres hilos, sin embargo se los lleva
                    acabo utilizando el método Prueba (que nace instanciado de un
                    método previamente definido), en primer lugar con un Contador
                    sin restricción y luego con uno que si presenta un bloqueo, por
                    lo que en ambos casos ocurren cosas distintas. 
   
                    Cuando se usa "Contar" sin bloqueo se tiende a tener errores, sin
                    embargo cuando se lo usa con bloqueo no, ya que las variables ya
                    no acceeden simultáneamente y arruinan los procesos cambiando
                    las variables (teniendo en cuenta el lock implementado).
   


                Practica01i:
                a. Explique claramente qué sucede en este caso. 
                    Se tiene dos casos de bloqueo:
                    En el primero de estos bloqueos lo que se hace es bloquearse para
                    que luego otro hilo intente seguir, cosa que hace porque no hay
                    limitante, este hace uso del monitor.
                    El segundo bloqueo realiza todo de manera similar, sin embargo no 
                    usa el monitor por lo que el hilo que quiere intentar entrar tiene 
                    que esperar hasta que se desbloquee el segmento de código, luego
                    se llega a un bloqueo DEADLOCK y muere.
   


                Practica01j:
                a. Explique claramente qué sucede en este caso. 
                    Al igual que en el punto g, se tiene que se crean hilos y se ejecutan
                    los métodos Prueba, sin embargo la diferencia es el tipo de contador
                    donde el segundo tiene un bloqueo para evitar la interrupción debido
                    a la simultaneidad. El método Interlocked funciona parecido al lock 
                    y evita que si se ejecutan de forma simultanea, se cambien los valores
                    por interrupción y sobreposición de hilos.
           
            2. RECOMENDACIONES:
               - Sebastián Cruz:
               Se recomienda nombrar archivos, proyectos, soluciones, variables, clases y
               demás elementos de forma clara para que el entendimiento de los scripts sea
               lo más sencillo posible y poder trabajar de una manera ordenada.

               - Jonathan Puente:
               Se recomienda tener en cuenta la organización de los archivos (las clases),
               ya que de no llevar este orden es muy probable que la confusión prime y no
               se pueda reutilizar el código agilmente, cosa que impera teniendo en cuenta
               los métodos que se han repetido.

            3. CONCLUSIONES:
               - Sebastián Cruz:
               Se ha aprendido a crear, manipular y destruir hilos dentro de procesos 
               mediante la elaboración de scripts que realizan distintas acciones con hilos.

               - Jonathan Puente:
               Se concluye que el tratamiento de hilos puede resultar muy voltatil, haciendo 
               referencia a lo fácil que puede ser no cumplir su objetivo, por ejemplo, en 
               el caso de que estos se bloqueen o no hagan caso a la acción programada para 
               hacerse. Este es el caso cuando los hilos sin restricciones se interponen 
               entre si o incluso si se programa para ser bloqueados y no lo hacen por alguna 
               situación. 
            */
            // *******************************************************************************

            //Creación de Hilos
            /*
            ImprimirNumeros();
            Thread hiloTrabajador = new Thread(ImprimirNumeros);
            hiloTrabajador.Start(); 
            */
            //Para realizarlo con un delegado en vez de unicamente enviar el metodo:
            ThreadStart delegadoThread = new ThreadStart(ImprimirNumeros);
            Thread hiloTrabajador1 = new Thread(delegadoThread);
            //Inicio el hilo:
            hiloTrabajador1.Start();
            ImprimirNumeros();

        }
        static void ImprimirNumeros()
        {
            Console.WriteLine("Empezando ....");
            for (int i = 1; i < 50; i++)
            {
                //Cambio para usar git
                Console.WriteLine(i);
            }
        }
    }
}
