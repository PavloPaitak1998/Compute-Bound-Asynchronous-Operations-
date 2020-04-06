using System;
using System.Threading.Tasks;

namespace _01Task.Example.Creation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Example_1 

            var task1 = new Task(() => Console.WriteLine("Foo"));
            task1.Start();

            //var task = new Task();

            #endregion

            #region Example_2

            var task2 = Task.Run(() => Console.WriteLine("Foo"));

            //var task = Task.Run();

            #endregion

            #region Example_3

            var task3 = Task.Factory.StartNew(() => Console.WriteLine("Foo"));

            //var task = Task.Factory.StartNew();

            #endregion
        }
    }
}