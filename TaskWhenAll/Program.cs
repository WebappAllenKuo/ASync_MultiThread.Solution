using System;
using System.Threading.Tasks;

namespace TaskWhenAll
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<int> t1 = Task.FromResult(1);
            Task<int> t2 = Task.FromResult(2);

            int[] results =await Task.WhenAll<int>(t1, t2);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}