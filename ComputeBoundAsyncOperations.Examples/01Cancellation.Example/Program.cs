﻿using System;
using System.Threading;

namespace _01Cancellation.Example
{
    class Program
    {
        public static void Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Pass the CancellationToken and the number-to-count-to into the operation
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            Console.WriteLine("Press <Enter> to cancel the operation.");
            Console.ReadLine();

            cts.Cancel(true);  // If Count returned already, Cancel has no effect on it
            // // Cancel returns immediately, and the method continues running here... 
            Console.ReadLine();
        }

        private static void Count(CancellationToken token, Int32 countTo)
        {
            for (Int32 count = 0; count < countTo; count++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break; // Exit the loop to stop the operation
                }

                Console.WriteLine(count);
                Thread.Sleep(200); // For demo, waste some time
            }

            Console.WriteLine("Count is done");
        }
    }
}