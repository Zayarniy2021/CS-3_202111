using System;
using System.Threading;

namespace List06
{
    class MyThread
    {
        public int Count;
        public Thread Thrd;

        // Notice that MyThread is also pass an int value. 
        //Обратите внимание, что MyThread так же использует int value
        public MyThread(string name, int data)
        {
            Count = 1;

            // Explicitly invoke ParameterizedThreadStart constructor 
            // for the sake of illustration. 
            // Для иллюстрации явно вызываем ParameterizedThreadStart контруктор,

            Thrd = new Thread(new ParameterizedThreadStart(this.Run));

            Thrd.Name = name;
            //Data data = new Data() { Delay = 500, Num = 10 };
            // Here, Start() is passed num as an argument. 
            Thrd.Start(data);
        }

        // Notice that this version of Run() has 
        // a parameter of type object. 
        void Run(object data)
        {
            Console.WriteLine(Thrd.Name +
                              " starting with count of " + ((int)data));

            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " + Thrd.Name +
                                  ", Count is " + Count);
                Count++;
            } while (Count <= (int)data);

            Console.WriteLine(Thrd.Name + " terminating.");
        }
    }

    class PassArgDemo
    {
        static void Main()
        {

            // Notice that the iteration count is passed 
            // to these two MyThread objects. 
            MyThread mt = new MyThread("Child #1", 10);
            MyThread mt2 = new MyThread("Child #2",20);

            do
            {
                Thread.Sleep(100);
                Console.Write(".");
            } 
            while (mt.Thrd.IsAlive | mt2.Thrd.IsAlive);

            Console.WriteLine("Main thread ending.");

            Console.Read();

        }
    }
}
