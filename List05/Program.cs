using System;
using System.Threading;

namespace List05
{

    class MyThread
    {
        public int Count;
        public Thread Thrd;

        public MyThread(string name)
        {
            Count = 0;
            Thrd = new Thread(new ThreadStart(this.Run));
            Thrd.Name = name;
            Thrd.Start();
        }

        // Entry point of thread. 
        void Run()
        {
            Console.WriteLine(Thrd.Name + " starting.");

            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " + Thrd.Name +
                                  ", Count is " + Count);
                Count++;
            } while (Count < 10);

            Console.WriteLine(Thrd.Name + " terminating.");
        }
    }

    // Use Join() to wait for threads to end. 
    class JoinThreads
    {
        static void Main()
        {
            Console.WriteLine("Main thread starting.");


            //Создаем и запускаем три потока
            MyThread mt1 = new MyThread("Child #1");
            MyThread mt2 = new MyThread("Child #2");
            MyThread mt3 = new MyThread("Child #3");
            //метод будет дожидаться окончания выполнения потока для которого 
            //вызван метод Join прежде чем пойти дальше (но это не значит, 
            //что другие потоки не могут выполняться параллельно!)
            mt1.Thrd.Join();
            Console.WriteLine("Child #1 joined.");

            mt2.Thrd.Join();
            Console.WriteLine("Child #2 joined.");

            mt3.Thrd.Join();
            Console.WriteLine("Child #3 joined.");

            Console.WriteLine("Main thread ending.");

            Console.ReadKey();

        }
    }
}
