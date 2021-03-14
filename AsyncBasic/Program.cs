using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBasic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // string url = "http://www.webapp.com.tw/";
            // Task<string> content = MyDownloadPageAsync(url);
            //
            // Console.WriteLine($"一共 {content.Result.Length} 個字元");

            int num1 = 10, num2 = 30;
            int sum = await MyTask(num1, num2);

            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
            }
            
            Console.WriteLine(sum);

        }

        static async Task<int> MyTask(int num1, int num2)
        {
            Thread.Sleep(5000);
            return num1 + num2;
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync(url);
                return content;
            }
        }
        static string MyDownloadPage(string url)
        {
            var client = new WebClient();
            string content = client.DownloadString(url);
            return content;
        }
    }
}