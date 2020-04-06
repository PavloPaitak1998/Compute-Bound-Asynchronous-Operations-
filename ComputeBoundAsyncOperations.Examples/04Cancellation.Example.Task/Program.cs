using System;
using System.Threading;
using System.Threading.Tasks;

namespace _04Cancellation.Example.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int32> t = System.Threading.Tasks.Task.Run(() => Sum(cts.Token, 1000000000), cts.Token);

            // Sometime later, cancel the CancellationTokenSource to cancel the Task
            cts.Cancel(); // This is an asynchronous request, the Task may have completed already 

            try
            {
                // If the task got canceled, Result will throw an AggregateException
                Console.WriteLine("The sum is: " + t.Result); // An Int32 value
            }
            catch (AggregateException x)
            {
                // Consider any OperationCanceledException objects as handled.
                // Any other exceptions cause a new AggregateException containing
                // only the unhandled exceptions to be thrown
                x.Handle(e => e is OperationCanceledException);

                // If all the exceptions were handled, the following executes
                Console.WriteLine("Sum was canceled");
            }
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {

                // The following line throws OperationCanceledException when Cancel
                // is called on the CancellationTokenSource referred to by the token
                ct.ThrowIfCancellationRequested();

                checked
                {
                    sum += n;
                } // if n is large, this will throw System.OverflowException
            }

            return sum;
        }
    }
}

/*
 
    Спочатку, необхідно щоб метод приймав CancellationToken параметр.

    У цьому коді цикл compute-bound операції періодично перевіряє, 
    чи операція була відмінена, викликавши метод ThrowIfCancellationRequested. 
    ThrowIfCancellationRequested викидає OperationCanceledException,
    якщо CancellationTokenSource був скасований. 
    Причина для викидання Exception-а полягає в тому, що, на відміну від work items, 
    ініційованих методом QueueUserWorkItem пула потоків, 
    task-и мають таке поняття як завершення, і task-и можуть повертати значення. 
    Отже, повинен бути спосіб відрізнити завершений task від скасованого, 
    і змушуючи task викидати Exception, дає вам змогу дізнатись, 
    що task виконався не до кінця, тобто був скасований.

    Створюючи task, ви можете пов’язати з ним CancellationToken, 
    передавши його у конструктору (як показано вище).
    Якщо CancellationToken буде скасовано до того як task буде запланований, 
    task скасовується і ніколи не виконаться. 
    Але якщо task вже був запланований (за допомогою виклику методу "Start"), 
    тоді метод task-а повинен явно підтримувати скасування, 
    якщо він дозволяє скасувати його роботу під час виконання. 
    На жаль, хоча об’єкт Task має обєкт CancellationToken, 
    до нього немає жодного способу, щоб доступитись, 
    тому вам потрібно якось отримати той самий CancellationToken, 
    який був використаний для створення об’єкта Task, у самому методі Task-а. 
    Найпростіший спосіб - використати лямбда-вираз і передати CancellationToken як параметр у метод (як я це робив у попередньому прикладі коду).
 */
