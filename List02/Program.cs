using System;
using System.Threading;

namespace List02
{

    class MyThread
    {
        public int Count;
        public Thread Thrd;

        public MyThread(string name)
        {
            Count = 0;
            Thrd = new Thread(this.Run);
            //Thrd.IsBackground = true;
            Thrd.Name = name; // set the name of the thread 
            Thrd.Start(); // start the thread 
        }
        void Run()
        {
            Console.WriteLine(Thrd.Name + " starting.");

            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " + Thrd.Name +
                                  ", Count is " + Count);
                Count++;
            } while (Count < 20);

            Console.WriteLine(Thrd.Name + " terminating.");
        }
    }


        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starting.");

            // First, construct a MyThread object. 
            MyThread mt = new MyThread("Child #1");

            do
            {
                Console.Write(".");
                Thread.Sleep(100);
            } while (mt.Count != 10);

            Console.WriteLine("Main thread ending.");

            //Console.Read();
        }
    }
}
