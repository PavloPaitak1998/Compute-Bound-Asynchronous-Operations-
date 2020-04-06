using System;
using System.Threading;

namespace _03ThreadPool.Example
{
    // Example IsThreadPoolThread
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Calling method using not ThreadPool thread.
            new Thread(
                    () => Console.WriteLine("Method 1: Is ThreadPool Thread - {0}", Thread.CurrentThread.IsThreadPoolThread))
                .Start();

            // Calling method using ThreadPool thread.
            ThreadPool.QueueUserWorkItem(
                (_) => Console.WriteLine("Method 2: Is ThreadPool Thread - {0}", Thread.CurrentThread.IsThreadPoolThread));

            Console.Read();
        }
    }
}
