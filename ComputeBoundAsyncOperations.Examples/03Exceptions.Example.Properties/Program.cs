using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03Exceptions.Example.Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: Start");

            Task task = Task.Run(() => throw null);
            //Task task = Task.Run(() => throw new OperationCanceledException());
            Thread.Sleep(1000);

            if (task.IsFaulted)
            {
                Console.WriteLine("Task is Faulted");
                Console.WriteLine("{0}: {1}", task.Exception.InnerException.GetType(), task.Exception.InnerException.Message);
            }

            if (task.IsCanceled)
            {
                Console.WriteLine("Task is Canceled");
            }

            //var result = faultedTask.Result;

            Console.WriteLine("Main: End");
        }
    }
}
