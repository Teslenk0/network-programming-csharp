namespace Ejemplos.Multithreading
{
    internal class Database
    {
        public void SaveData(string text)
        {
            try
            {
                Monitor.Enter(this);

                Console.WriteLine("Database.SaveData - Iniciado");

                Console.WriteLine("Database.SaveData - Ejecutandose");

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);

                    Console.Write(text);
                }

                throw new Exception("ERROR");

                Console.WriteLine("\nDatabase.SaveData - Finalizado");

            }
            catch
            {

            }
            finally
            {
                Monitor.Exit(this);

            }

        }
    }

    internal class ThreadMonitor
    {
        public static Database db = new Database();

        public static void WorkerThreadMethod1()
        {
            Console.WriteLine("Hilo de ejecucion secundarion #1 iniciado");

            Console.WriteLine("Hilo de ejecucion secundario #1 invocando Database.SaveData");

            db.SaveData("X");

            Console.WriteLine("Hilo de ejecucion secundario #1 Retornando desde Output");
        }

        public static void WorkerThreadMethod2()
        {
            Console.WriteLine("Hilo de ejecucion secundarion #2 iniciado");

            Console.WriteLine("Hilo de ejecucion secundario #2 invocando Database.SaveData");

            db.SaveData("O");

            Console.WriteLine("Hilo de ejecucion secundario #2 Retornando desde Output");
        }

        public static void MainOld()
        {
            Console.WriteLine("Principal - Creando hilos de ejecucion secundarios");

            Thread t1 = new(WorkerThreadMethod1);
            Thread t2 = new(WorkerThreadMethod2);

            t1.Start();

            t2.Start();
        }
    }
}
