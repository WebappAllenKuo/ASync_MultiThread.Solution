using System;
using System.Threading;
using NUnit.Framework;

namespace ASync_MultiThreadExec
{
    public class NewThread
    {
        [Test]
        public void Test()
        {
            Thread t = new Thread(DoSomething);
            t.Start("aaa");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
            }
            
        }

        public void DoSomething(object name)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(i + "\t");
                // Thread.Sleep(1000);
            }

            Console.WriteLine("\n");
        }
    }
}