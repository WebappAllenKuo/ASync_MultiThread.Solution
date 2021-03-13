using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TplBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(() => MyTask());
            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
            }
        }

        static void MyTask()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write($"[{Thread.CurrentThread.ManagedThreadId}]");
                Thread.Sleep(1);
            }

            Console.WriteLine("MyTask End.");
        }
    }
}