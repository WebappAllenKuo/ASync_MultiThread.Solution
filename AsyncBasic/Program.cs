using System;
using System.Net;

namespace AsyncBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.webapp.com.tw/";
            string content = MyDownloadPage(url);

            Console.WriteLine($"一共 {content.Length} 個字元");

        }

        static string MyDownloadPage(string url)
        {
            var client = new WebClient();
            string content = client.DownloadString(url);
            return content;
        }
    }
}