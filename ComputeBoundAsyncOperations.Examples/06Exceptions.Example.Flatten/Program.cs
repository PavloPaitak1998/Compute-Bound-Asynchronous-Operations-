using System;
using System.Threading;
using System.Threading.Tasks;

namespace _06Exceptions.Example.Flatten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: Start");
            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    new Task(() => throw new NullReferenceException(), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => throw new InvalidCastException(), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() =>
                    {
                        new Task(() => throw new InvalidOperationException(), TaskCreationOptions.AttachedToParent)
                            .Start();
                        new Task(() => throw new ArgumentNullException(), TaskCreationOptions.AttachedToParent).Start();
                    }, TaskCreationOptions.AttachedToParent).Start();
                });

                task.Wait();

                Thread.Sleep(1000);
                Console.WriteLine("Main: Ends");
            }
            catch (AggregateException aex)
            {
                var newAex = aex.Flatten();
                foreach (Exception ex in newAex.Flatten().InnerExceptions)
                    Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message);
            }
        }
    }
}
