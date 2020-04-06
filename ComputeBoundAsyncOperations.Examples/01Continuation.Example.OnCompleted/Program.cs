using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _01Continuation.Example.OnCompleted
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(2000); //Comment
                return 1;
            });

            var awaiter = task.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result); // Writes result
            });

            Console.ReadLine();
        }
    }
}
