using System;
using System.Threading;

namespace _02ThreadPool.Example
{
    // Example of change Background thread on Foreground
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main thread: Start");

            var sync = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(_ =>
                {
                    Console.WriteLine("ComputeBoundOp: Start");

                    // Changes Background thread on Foreground
                    //Thread.CurrentThread.IsBackground = false; // Uncomment

                    sync.Set();

                    if (!Thread.CurrentThread.IsBackground)
                    {
                        Console.WriteLine("Program will not end until all Foreground threads end");
                    }
                    Thread.Sleep(5000);
                    Console.WriteLine("ComputeBoundOp: Finished");

                    // When this method returns, the program ends
                });

            sync.WaitOne();  // Ensures IsBackground is set

            Console.WriteLine("Main thread: Doing other work here...");
            Console.WriteLine("Main thread: Ends");
        }
    }
}
