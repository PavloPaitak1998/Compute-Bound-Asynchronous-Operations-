using System;
using System.Threading;
using System.Threading.Tasks;

namespace _01Exceptions.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main: Start");

                Task<int> faultedTask = Task.Run(() => { throw null; return -1; });
                
                faultedTask.Wait();
                //var result = faultedTask.Result;

                Thread.Sleep(1000);
                Console.WriteLine("Main: End");
            }
            catch (AggregateException ag)
            {
                Console.WriteLine("Main: Faulted");

                Console.WriteLine("{0}: {1}", ag.InnerException.GetType(), ag.InnerException.Message);
            }
        }
    }
}
