namespace Ejemplos.Multithreading
{
    internal class PingPong
    {
        public void Ping(bool running)
        {
            lock (this)
            {
                if (!running)
                {
                    // ball halts
                    Monitor.Pulse(this); // notify waiting threads
                    return;
                }

                Console.Write("Ping ");
                Monitor.Pulse(this); // let pong() run
                Monitor.Wait(this); //wait for pong() to complete
            }
        }

        public void Pong(bool running)
        {
            lock (this)
            {
                if (!running)
                {
                    // ball halts
                    Monitor.Pulse(this); // notify waiting threads
                    return;
                }

                Console.Write("Pong ");
                Monitor.Pulse(this); // let pong() run
                Monitor.Wait(this); //wait for pong() to complete
            }
        }
    }

    internal class PingPongThread
    {
        public Thread thread;

        PingPong pingPong;

        public PingPongThread(string name, PingPong pingPong)
        {
            this.pingPong = pingPong;

            thread = new(Run)
            {
                Name = name
            };

            thread.Start();
        }

        public void Run()
        {
            if (thread.Name == "Ping")
            {
                for (int i = 0; i < 5; i++)
                {
                    pingPong.Ping(true);
                }
                pingPong.Ping(false);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    pingPong.Pong(true);
                }
                pingPong.Pong(false);
            }
        }
    }

    internal class Runner
    {
        public static void OldMain()
        {
            PingPong pingPong = new PingPong();

            Console.WriteLine("The ball is dropped");

            PingPongThread thread1 = new PingPongThread("Ping", pingPong);
            PingPongThread thread2 = new PingPongThread("Pong", pingPong);

            thread1.thread.Join();
            thread2.thread.Join();

            Console.WriteLine("The ball stops bouncing");

            Console.Read();

        }
    }
}