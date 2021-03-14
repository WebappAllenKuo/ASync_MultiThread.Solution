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
            Log(1,"正要起始非同步 MyDownloadPageAsync.");
            
            var task = MyDownloadPageAsync("http://www.webapp.com.tw/");

            Log(4,"從 MyDownloadPageAsync 返回，但目前尚未取得工作結果");
            
            string content = await task;

            Log(6,"已經取得 MyDownloadPageAsync 結果");
            
            Console.WriteLine($"總共內容 {content.Length} 字元");
        }

        static void Log(int num, string msg)
        {
            Console.WriteLine($"<{num}> T{Thread.CurrentThread.ManagedThreadId}: {msg}");
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            Log(2, "MyDownloadPageAsync Start.");
            
            using (var wc = new WebClient())
            {
                var task = wc.DownloadStringTaskAsync(url);
                
                Log(3,"wc.DownloadStringTaskAsync start.");
                
                string content = await task;

                Log(5,"已經取得網頁內容");
                
                return content;
            }
        }
    }
}