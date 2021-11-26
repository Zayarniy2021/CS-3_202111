using System;
using System.Threading.Tasks;

namespace AsyncSimplestExample
{
    class Program
    {

        async static void AddAsync()
        {
            await Task.Factory.StartNew((o) => Console.WriteLine(o),"123");
        }

        static void Main(string[] args)
        {
            AddAsync();
            Console.ReadKey();
        }

        static void Sum(object a)
        {
            Console.WriteLine(a);
        }

    }
}
