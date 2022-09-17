using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Multithreading
{
    internal class EjemploSemaforos
    {

        static Thread[] threads = new Thread[10];

        static Semaphore sem = new Semaphore(3, 3);

        static void CSharpCorner()
        {
            Console.WriteLine("{0} is waiting in line...", Thread.CurrentThread.Name);

            sem.WaitOne();

            Console.WriteLine("{0} enters the zone!", Thread.CurrentThread.Name);

            Thread.Sleep(300);

            Console.WriteLine("{0} is leaving the zone!", Thread.CurrentThread.Name);

            sem.Release();
        }

        static void OldMain(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(CSharpCorner);

                threads[i].Name = "Thread-#" + i;

                threads[i].Start();
            }

            Console.Read();
        }
    }
}
