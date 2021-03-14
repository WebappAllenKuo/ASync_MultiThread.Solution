using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDelay
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var task = MyTaskAsync();
            Log(1,"已叫用MyTaskAsync .");

            await task;
            Log(3,"task complete");
            
        }

        static void Log(int num, string msg)
        {
            Console.WriteLine($"<{num}> T{Thread.CurrentThread.ManagedThreadId} : {msg}");
        }

        static async Task MyTaskAsync()
        {
            Log(0,"MyTaskAsync Start.");
            
            await Task.Delay(1000);

            Log(2,"MyTaskAsync End.");
        }
    }
}