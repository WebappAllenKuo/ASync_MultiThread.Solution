using System;
using System.Net;
using System.Threading.Tasks;

namespace AsyncBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.webapp.com.tw/";
            Task<string> content = MyDownloadPageAsync(url);

            Console.WriteLine($"一共 {content.Result.Length} 個字元");

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