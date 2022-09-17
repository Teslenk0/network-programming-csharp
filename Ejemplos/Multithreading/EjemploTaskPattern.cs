using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Multithreading
{
    internal delegate void FinishTask(AbstractTask abstractTask);

    internal abstract class AbstractTask
    {
        private Thread _thread;

        private FinishTask _finishTask;

        public AbstractTask()
        {
            this._thread = null;
        }

        public void Execute(FinishTask finishTask)
        {
            this._finishTask = finishTask;

            this._thread = new Thread(this.FinishTask);

            this._thread.Start();
        }

        public void WaitForFinish()
        {
            if (this._thread != null)
            {
                this._thread.Join();
            }
        }

        private void FinishTask()
        {
            this.Process();

            if (this._finishTask != null) this._finishTask.Invoke(this);
        }

        protected abstract void Process();
    }

    internal class ConcreteTask : AbstractTask
    {
        public ConcreteTask() : base()
        {

        }
        protected override void Process()
        {
            Console.WriteLine("Starting concrete task");

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine("Running Task iteration " + i);
            }

            Console.WriteLine("Finishing concrete Task!");
        }
    }

    internal class EjemploTaskPattern
    {

        public static void OldMain(string[] args)
        {
            Console.WriteLine("Starting test");

            AbstractTask concreteTask = new ConcreteTask();

            concreteTask.Execute(PrintFinish);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine("Running Code in Main " + i);
            }

            concreteTask.WaitForFinish();

            Console.WriteLine("Finished Main");
        }


        public static void PrintFinish(AbstractTask task)
        {
            Console.WriteLine("Finished task: " + task);
        }

    }
}
