using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(MyTask); // 用 Thread Pool 來建立多執行緒，它是背景thread
            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
            }
        }

        static void MyTask(object state)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write($"[{Thread.CurrentThread.ManagedThreadId}]");
                Thread.Sleep(10);
            }
            
        }
    }
}