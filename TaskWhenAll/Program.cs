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

            Task<int> t1 = MyTask1(); // 這裡不會卡
            Task<string> t2 = MyTask2(); //這裡不會卡

            await Task.WhenAll(t1, t2); // 這裡會卡10秒，等二個都完成，才再向下
            int num = await t1; //由於已完成，所以這裡可以直接取值，不會卡
            string value = await t2;//由於已完成，所以這裡可以直接取值，不會卡
            
        }

        static async Task<int> MyTask1()
        { 
            await Task.Delay(6000);
            return 1;
        }
        static async Task<string> MyTask2()
        {
            await Task.Delay(10000);
            return "allen";
        }
        
    }
}