using System;
using System.Threading;
using System.Threading.Tasks;

namespace _04Task.Example.Status
{
    class Program
    {
        static void Main(string[] args)
        {
            // IsCompletedSuccessfully
            // IsCompleted
            // IsCanceled
            // IsFaulted

            var task1 = Task.Run(() => Thread.Sleep(1));
            Thread.Sleep(100);

            Console.WriteLine("Task1: Succeed");
            Console.WriteLine("IsCompletedSuccessfully {0}", task1.IsCompletedSuccessfully);
            Console.WriteLine("IsCompleted {0}", task1.IsCompleted);
            Console.WriteLine("IsCanceled {0}", task1.IsCanceled);
            Console.WriteLine("IsFaulted {0}", task1.IsFaulted);
            Console.WriteLine();

            var task2 = Task.Run(() => throw null);
            Thread.Sleep(100);

            Console.WriteLine("Task2: Faulted");
            Console.WriteLine("IsCompletedSuccessfully {0}", task2.IsCompletedSuccessfully);
            Console.WriteLine("IsCompleted {0}", task1.IsCompleted);
            Console.WriteLine("IsCanceled {0}", task2.IsCanceled);
            Console.WriteLine("IsFaulted {0}", task2.IsFaulted);
            Console.WriteLine();

            var task3 = Task.Run(() => throw new OperationCanceledException());
            Thread.Sleep(100);

            Console.WriteLine("Task3: Canceled");
            Console.WriteLine("IsCompletedSuccessfully {0}", task3.IsCompletedSuccessfully);
            Console.WriteLine("IsCompleted {0}", task1.IsCompleted);
            Console.WriteLine("IsCanceled {0}", task3.IsCanceled);
            Console.WriteLine("IsFaulted {0}", task3.IsFaulted);
            Console.WriteLine();
        }
    }
}
