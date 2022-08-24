class Ejemplo1
{
    public static void WorkerThreadMethod1()
    {
        Console.WriteLine("Hilo de ejecucion secundario iniciado");
        Console.WriteLine("Hilo de ejecucion secundario - Contando lentamente de 1 a 10");

        for (int j = 0; j < 11; j++)
        {
            Console.Write("[#2]");
            for (int i = 0; i < 100; i++)
            {
                Console.Write('.');
                int a;
                a = 15;
            }

            Console.WriteLine("{0}", j);
        }

        Console.WriteLine("Hilo de ejecucion secundario finalizado");
    }

    public static void WorkerThreadMethod2()
    {
        Console.WriteLine("Hilo de ejecucion terciario iniciado");
        Console.WriteLine("Hilo de ejecucion terciario - Contando lentamente de 11 a 20");

        for (int j = 11; j < 20; j++)
        {
            Console.Write("[#3]");
            for (int i = 0; i < 100; i++)
            {

                int a;
                a = 15;
            }

            Console.WriteLine("{0}", j);
        }

        Console.WriteLine("Hilo de ejecucion terciario finalizado");
    }

    public static void OldMain()
    {

        // ThreadStart worker = new ThreadStart(WorkerThreadMethod);

        Console.WriteLine("[Main] - Creating worker thread");

        Thread t1 = new Thread(() => WorkerThreadMethod1());

        Thread t2 = new Thread(() => WorkerThreadMethod2());

        t1.Priority = ThreadPriority.Highest;

        t2.Priority = ThreadPriority.Lowest;

        t1.Start();
        t2.Start();
    }
}