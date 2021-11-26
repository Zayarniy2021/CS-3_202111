using System;
using System.Threading;

namespace List01
{
    class Program
    {

        static void Run()
        {
            int Count=0;
            Console.WriteLine( " starting.");
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " +
                                  ", Count is " + Count);
                Count++;
            } while (Count < 20);

            Console.WriteLine( " terminating.");
        }

    

        static void Main(string[] args)
        {
            Thread newThrd = new Thread(Run);
            Thread newThrd1 = new Thread(Run);
            Thread newThrd2 = new Thread(Run);
            //newThrd.IsBackground = true;//фоновым
            newThrd.Start();
            Console.WriteLine("Main is finished");
        }

    }
}
