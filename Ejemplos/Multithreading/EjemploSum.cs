namespace Ejemplos.Multithreading
{

    internal class EjemploSum
    {
        int op1;
        int op2;
        int result;
        public EjemploSum(int op1, int op2)
        {
            Console.WriteLine("[Sum.Sum] Instantiated with values of {0} and {1}", op1, op2);

            this.op1 = op1;
            this.op2 = op2;
        }

        public int Result { get { return result; } }

        public void Add()
        {
            Thread.Sleep(5000);
            result = op1 + op2;
        }
    }

    internal class ThreadData
    {
        static void OldMain()
        {
            Console.WriteLine("[Main] Instantiating the Sum object and passing it the values to add");

            EjemploSum sum = new EjemploSum(6, 42);

            Console.WriteLine("[Main] Starting a thread using a sum delegate");

            Thread thread = new Thread(new ThreadStart(sum.Add));

            thread.Start();

            Console.WriteLine("[Main] Doing other work");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine(".");
            }

            Console.WriteLine("\n [Main] Waiting for Add to finish");

            thread.Join();

            Console.WriteLine("[Main] The result is: {0}", sum.Result);

            Console.ReadLine();
        }
    }
}
