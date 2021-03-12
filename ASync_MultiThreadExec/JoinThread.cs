using System;
using System.Threading;
using NUnit.Framework;

namespace ASync_MultiThreadExec
{
    public class JoinThread
    {

        [Test]
        public void Test()
        {
            Thread t1 = new Thread(DoJob);
            Thread t2 = new Thread(DoJob);
            Thread t3 = new Thread(DoJob);
            
            t1.Start("X");
            t2.Start("Y");
            t3.Start("Z");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
            }
            
            // t1.Join();
            // t2.Join();
            // t3.Join();
            
           // 沒有寫join(),所以下一行程式有可能比上面三個thread還要早執行
            Console.WriteLine("[XXXXXXXXXXXXXXXX]");
        }

        public void DoJob(object name)
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.Write(name + " ");
                // Thread.Sleep(10);
            }
        }
    }
}