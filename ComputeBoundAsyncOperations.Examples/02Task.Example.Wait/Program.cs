using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02Cancellation.Example.Wait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Foo"); });

            Console.WriteLine("Task Is Completed: {0}", task.IsCompleted);  // False

            task.Wait();  // Blocks until task is complete 

            //task.Wait(1000);

            Console.WriteLine("Task Completed");
        }
    }
}
