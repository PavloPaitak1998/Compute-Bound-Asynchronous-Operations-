using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02Continuation.Example.ContinueWith__
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and start a Task
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(2000); //Comment
                return 1;
            });

            // ContinueWith returns a Task but you usually don't care
            Task cwt = task.ContinueWith(t =>
            {
                int result = t.Result;
                Console.WriteLine(result);
            });

            Console.ReadLine();
        }
    }
}
