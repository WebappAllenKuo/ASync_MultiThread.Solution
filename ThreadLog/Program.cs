using System;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var task = MyDownloadPageAsync("http://www.webapp.com.tw/");

            string content = await task;

            Console.WriteLine($"總共內容 {content.Length} 字元");
        }

        static void Log(int num, string msg)
        {
            Console.WriteLine($"<{num}> T{Thread.CurrentThread.ManagedThreadId}: {msg}");
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {

            using (var wc = new WebClient())
            {
                var task = wc.DownloadStringTaskAsync(url);

                string content = await task;

                return content;
            }
        }
    }
}