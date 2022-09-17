using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Multithreading
{
    internal class EjemploBackgroundWorker
    {
        public static void OldMain(string[] args)
        {
            Console.WriteLine("Starting test!");

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += WorkerFunction;

            bw.RunWorkerCompleted += FinishFunction;

            bw.RunWorkerAsync();

            for(var i = 0; i<10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine("Running code in Main: " + i);
            }

            Console.ReadLine();
        }

        static void WorkerFunction(object sender, DoWorkEventArgs e) 
        {

            Console.Write("Started working...");

            for(var i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine("Iteration: " + i);
            }
        }

        static void FinishFunction(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("FINISH FUNCTION");
        }

    }
}
