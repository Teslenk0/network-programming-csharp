using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Practico_1
{
    internal class PrinterLock
    {
        public void PrintLetter(string letter)
        {
            lock (this)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(letter);
                    Thread.Sleep(100);
                }
            }

        }
    }

    internal class PrinterSemaphores
    {
        private Semaphore sem;

        internal PrinterSemaphores()
        {
            this.sem = new Semaphore(1, 1);
        }

        internal void PrintLetter(string letter)
        {
            sem.WaitOne();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(letter);
                Thread.Sleep(100);
            }

            sem.Release();
        }
    }

    internal class Ejercicio1
    {
       
        public static void OldMain(string[] args)
        {
            PrinterSemaphores p = new PrinterSemaphores();

            Thread t1 = new(() => p.PrintLetter("x"));

            Thread t2 = new(() => p.PrintLetter("y"));

            t1.Start();

            t2.Start();

            Console.ReadLine();
        }
    }
}
