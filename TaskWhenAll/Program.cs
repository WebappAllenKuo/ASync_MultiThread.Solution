using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWhenAll
{
    class Program
    {
        static async Task Main(string[] args)
        {
            https://stackoverflow.com/questions/17197699/awaiting-multiple-tasks-with-different-results

            Task<int> t1 = MyTask1(); // 這裡會卡 6秒才再向下
            Task<string> t2 = MyTask2(); //這裡會卡 10秒才再向下

            await Task.WhenAll(t1, t2); // 由於上二行都完成，所以不會卡住，直接向下
            int num = await t1;
            string value = await t2;
            
            // foreach (var result in results)
            // {
            //     Console.WriteLine(result);
            // }
        }

        static async Task<int> MyTask1()
        {
            Thread.Sleep(6000);
            return 1;
        }
        static async Task<string> MyTask2()
        {
            Thread.Sleep(10000);
            return "allen";
        }
        
    }
}