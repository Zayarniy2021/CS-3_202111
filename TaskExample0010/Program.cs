using System;
using System.Threading;
using System.Threading.Tasks;


namespace TaskExample0010
{
    class Program
    {
        static void MyTask()
        {
            Thread.CurrentThread.IsBackground = true;//фоновый
            Thread.CurrentThread.IsBackground = false;//приоритетным
            Console.WriteLine("MyTask() starting");
            Console.WriteLine("IsBackground:" + Thread.CurrentThread.IsBackground);
            //Выполняет работу в потоке
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask(), count is " + count);
            }

            Console.WriteLine("MyTask terminating");

        }
        static void Main(string[] args)
        {
            Task tsk = new Task(new Action(MyTask));
            tsk.Start();

            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }

            Console.WriteLine("Main thread ending.");


        }
    }
}
