using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace ASync_MultiThreadExec
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // [Test]
        // public void Test1()
        // {
        //     Console.WriteLine("Test1 Start...");
        //     
        //     var job = new MyJob();
        //     job.DoALongJob();
        //     
        //     Console.WriteLine("Test1 End...");
        // }
        
        [Test]
        public async Task Test2()
        {
            Console.WriteLine("Test1 Start...");
            
            var job = new MyJob();

            await job.DoALongJob();
            
            Console.WriteLine("Test1 End...");
        }
    }

    class MyJob
    {
        public async Task DoALongJob()
        {
            Console.WriteLine("DoALongJob Start...");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"i = {i}\t");
                await Task.Delay(1500);
            }

            Console.Write("\n");
            
            Console.WriteLine("DoALongJob End...");

            //return Task.FromResult();
        }
    }
}