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
            var t1 = new Task(MyTask); // TPL是在thread pool 執行，所以是背景thread,主程式結束，它就被迫結束
            t1.Start();
            t1.Wait(); // 會丟到task完全結束，才再向下執行
            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
                // Thread.Sleep(100);
            }
        }

        static void MyTask()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write($"[{Thread.CurrentThread.ManagedThreadId}]");
                //Thread.Sleep(1);
            }
        }
    }
}