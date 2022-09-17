using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Practico_1
{
    internal class ZeroPrinter
    {
        internal void PrintLetter()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(0);
                Thread.Sleep(100);
            }
        }
    }

    internal class Ejercicio2
    {
        public static void OldMain(string[] args)
        {
            ZeroPrinter p = new ZeroPrinter();

            Thread t1 = new(p.PrintLetter);

            t1.Start();

            t1.Join();

            Console.WriteLine("Thred 1 termino");

            Console.ReadLine();
        }
    }
}
