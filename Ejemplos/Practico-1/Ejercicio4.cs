using Ejemplos.Multithreading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Practico_1
{
    internal delegate void TaskToSchedule(int threadNumber);

    internal class ThreadManager
    {
        public void ScheduleTask(TaskToSchedule taskToSchedule, int threadNumber)
        {
            var thread = new Thread(() => taskToSchedule.Invoke(threadNumber));

            thread.Start();
        }
    }

    internal class ThreadPrinter
    {
        private Semaphore semaphore;

        public ThreadPrinter()
        {
            this.semaphore = new Semaphore(0, 10);
        }

        public void PrintThreadNumber(int number)
        {
            semaphore.WaitOne();

            Console.WriteLine("Thread #{0}", number);

            semaphore.Release();
        }

        public void EnablePrinter()
        {
            semaphore.Release();
        }
    }

    internal class Ejercicio4
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                ThreadManager threadManager = new ThreadManager();

                ThreadPrinter threadPrinter = new ThreadPrinter();

                for (int i = 0; i < 10; i++)
                {
                    threadManager.ScheduleTask(threadPrinter.PrintThreadNumber, i);
                }

                var input = Console.ReadLine();

                if (input == "start")
                {
                    threadPrinter.EnablePrinter();
                }
                else if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found");
                }
            }

        }
    }
}
