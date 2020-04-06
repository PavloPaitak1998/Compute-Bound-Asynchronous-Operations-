using System;
using System.Threading.Tasks;

namespace _03Task.Example.Result
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task1 = Task.Run(() => { Console.WriteLine("Foo"); return 3; });

            // As Task<int> inherits Task you can simplify your code as this.
            Task<int> task2 = Task<int>.Run(() => { Console.WriteLine("Foo"); return 3; });

            task1.Wait(); // You can omit the Result property internally calls Wait

            int result = task1.Result;      // Blocks if not already finished
            Console.WriteLine (result);    // 3 
        }
    }
}
