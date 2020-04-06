using System;
using System.Threading;

namespace _02Cancellation.Example.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var cancellationTokenRegistration1 = cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            var cancellationTokenRegistration2 = cts.Token.Register(() => Console.WriteLine("Canceled 2"));

            //cancellationTokenRegistration1.Dispose();
            //cancellationTokenRegistration2.Dispose();

            // To test, let's just cancel it now and have the 2 callbacks execute
            cts.Cancel();

            // Canceled 2
            // Canceled 1
            Console.ReadLine();
        }
    }
}