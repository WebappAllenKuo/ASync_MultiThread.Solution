using System;
using System.Threading;

namespace BackgroundThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(MyTask); 
            t1.IsBackground = true; // 若設為背景thread, 只會執行一下下，就會因為主thread結束而不再執行背景thread
            t1.Start();
        }

        static void MyTask()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}