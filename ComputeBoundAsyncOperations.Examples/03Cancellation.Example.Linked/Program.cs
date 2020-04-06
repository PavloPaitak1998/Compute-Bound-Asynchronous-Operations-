using System;
using System.Threading;

namespace _03Cancellation.Example.Linked
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a CancellationTokenSource
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled")); 

            // Create another CancellationTokenSource
            var cts2 = new CancellationTokenSource(); 
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled")); 

            // Create a new CancellationTokenSource that is canceled when cts1 or ct2 is canceled
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token); 
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled")); 

            // Cancel one of the CancellationTokenSource objects (I chose cts2)
            cts2.Cancel(); 

            // Display which CancellationTokenSource objects are canceled
            Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts canceled={2}"
                , cts1.IsCancellationRequested
                , cts2.IsCancellationRequested
                , linkedCts.IsCancellationRequested); 

            // When I run the code above, I get the following output: 
            // linkedCts canceled cts2 canceled cts1 canceled = False, cts2 canceled = True, linkedCts canceled = True
            Console.ReadLine();
        }
    }
}
