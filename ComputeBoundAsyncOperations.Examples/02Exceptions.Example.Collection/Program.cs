using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02Exceptions.Example.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: Start");
            try
            {
                Task faultedTask = Task.Factory.StartNew(() =>
                {
                    new Task(() => throw new NullReferenceException(), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => throw new InvalidCastException(), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => throw new ArgumentException(), TaskCreationOptions.AttachedToParent).Start();
                });

                faultedTask.Wait();

                Thread.Sleep(1000);
                Console.WriteLine("Main: Ends");
            }
            catch (AggregateException ag)
            {
                Console.WriteLine("Main: Faulted");

                foreach (var ie in ag.GetBaseException  InnerExceptions)
                {
                    Console.WriteLine("{0}: {1}", ie.GetType(), ie.Message);
                }
            }
        }
    }
}
