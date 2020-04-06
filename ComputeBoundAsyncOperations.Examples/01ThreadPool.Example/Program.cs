using System;
using System.Threading;

namespace _01ThreadPool.Example
{
    // Example of queueing user work item
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main thread: Start");

            // Queues a method for execution
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);

            
            Console.WriteLine("Main thread: Doing other work here...");

            Thread.Sleep(3000);  // Simulating other work (3 seconds)

            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
            Console.WriteLine("Main thread: Ends");
        }

        // This method's signature must match the WaitCallback delegate
        // "public delegate void WaitCallback(object? state);"
        private static void ComputeBoundOp(object state) // This method is executed by a thread pool thread  
        {
            Console.WriteLine("ComputeBoundOp: Start");
            Console.WriteLine("ComputeBoundOp: state={0}", state);

            Thread.Sleep(1000);  // Simulates other work (1 second)  

            Console.WriteLine("ComputeBoundOp: Finished");

            // When this method returns, the thread goes back
            // to the pool and waits for another task
        }
    }
}
