using System;
using System.Threading;

/*
 ThreadPool.SetMinThreads(Int32, Int32) - Sets the minimum number of threads the thread pool creates on demand, as new requests are made, 
                                          before switching to an algorithm for managing thread creation and destruction.

 ThreadPool.GetMinThreads(Int32, Int32) - Retrieves the minimum number of threads the thread pool creates on demand, as new requests are made, 
                                          before switching to an algorithm for managing thread creation and destruction.

 ThreadPool.SetMaxThreads(Int32, Int32) - Sets the number of requests to the thread pool that can be active concurrently.
                                          All requests above that number remain queued until thread pool threads become available.


 ThreadPool.GetMaxThreads(Int32, Int32) - Retrieves the number of requests to the thread pool that can be active concurrently.
                                          All requests above that number remain queued until thread pool threads become available.

 ThreadPool.GetAvailableThreads(Int32, Int32) - Retrieves the difference between the maximum number of thread pool threads
                                                returned by the GetMaxThreads(Int32, Int32) method, and the number currently active.

*/
namespace _04ThreadPool.Example
{
    internal class Program
    {
        // Example ThreadPool thread control
        private static void Main(string[] args)
        {
            #region min

            // Gets the current min number of worker and completion port threads.
            ThreadPool.GetMinThreads(out var minWorker, out var minIOC);

            #region Console.WriteLine

            Console.WriteLine("Default minimum number of worker threads: {0}", minWorker);
            Console.WriteLine("Default minimum number of I/O completion threads: {0}", minIOC);
            Console.WriteLine();

            #endregion

            // Changes the min number of worker and completion port threads to 4.
            if (ThreadPool.SetMinThreads(4, 4))// Change to 32768 and 0
            {
                ThreadPool.GetMinThreads(out minWorker, out minIOC);

                #region Console.WriteLine

                Console.WriteLine("Changed minimum number of worker threads: {0}", minWorker);
                Console.WriteLine("Changed minimum number of I/O completion threads: {0}", minIOC);
                Console.WriteLine();

                #endregion
            }
            else
            {
                #region Console.WriteLine

                Console.WriteLine("The minimum number of threads was not changed.");
                Console.WriteLine();

                #endregion
            }

            #endregion

            #region max

            // Gets the max number of worker and completion port threads.
            ThreadPool.GetMaxThreads(out var maxWorker, out var maxIOC);

            #region Console.WriteLine

            Console.WriteLine("Default maximum number of worker threads: {0}", maxWorker);
            Console.WriteLine("Default maximum number of I/O completion threads: {0}", maxIOC);
            Console.WriteLine();

            #endregion

            // Changes the max number of worker and completion port threads to 4.
            if (ThreadPool.SetMaxThreads(4, 4))// Change to 32768 and 0
            {
                ThreadPool.GetMaxThreads(out maxWorker, out maxIOC);

                #region Console.WriteLine

                Console.WriteLine("Changed maximum number of worker threads: {0}", maxWorker);
                Console.WriteLine("Changed maximum number of I/O completion threads: {0}", maxIOC);
                Console.WriteLine();

                #endregion
            }
            else
            {
                #region Console.WriteLine

                Console.WriteLine("The maximum number of threads was not changed.");
                Console.WriteLine();

                #endregion

            }

            #endregion

            #region available

            ThreadPool.QueueUserWorkItem((_) => Thread.Sleep(5000));

            // Retrieves the difference between the max number of thread pool threads and the number currently active.
            ThreadPool.GetAvailableThreads(out var Worker, out var IOC);

            #region Console.WriteLine

            Console.WriteLine("Available number of worker threads: {0}", Worker);
            Console.WriteLine("Available number of I/O completion threads: {0}", IOC);

            #endregion

            #endregion

            Console.ReadLine();
        }
    }
}
