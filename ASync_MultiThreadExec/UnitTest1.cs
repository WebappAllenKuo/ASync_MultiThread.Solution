using System;
using System.Threading;
using NUnit.Framework;

namespace ASync_MultiThreadExec
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1 Start...");
            
            var job = new MyJob();
            job.DoALongJob();
            
            Console.WriteLine("Test1 End...");
        }
    }

    class MyJob
    {
        public void DoALongJob()
        {
            Console.WriteLine("DoALongJob Start...");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"i = {i}\t");
                Thread.Sleep(1500);
            }

            Console.Write("\n");
            
            Console.WriteLine("DoALongJob End...");
        }
    }
}