using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Practico_1
{
    internal class Calculator
    {
        internal int Suma(int a, int b)
        {
            return a + b;
        }

        internal int SumaTriple(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    internal class Ejercicio3
    {
        public static void OldMain(string[] args)
        {
            Calculator c = new();

            var result = 0;

            Thread t1 = new(() => { result += c.Suma(4, 3); });

            Thread t2 = new(() => { result += c.SumaTriple(40, 10, 20); });

            t1.Start();

            t2.Start();

            t1.Join();

            t2.Join();

            Console.WriteLine("Resultado: {0}", result);

            Console.ReadLine();
        }
    }
}
