using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExec
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Main start.",1);

            string url = "http://www.google.com/";
            DownloadStringAsync(url); // 由於非同步尚未完成，main 就結束了，所以background thread自動也結束
            
            Log("Main end.", 2);
        }

        static void DownloadString(string url)
        {
            using (var client =new WebClient())
            {
                string content = client.DownloadString(url);
                Log($"DownloadString/content has {content.Length} chars.");
            }
        }
        
        static async Task DownloadStringAsync(string url)
        {
            using (var client =new HttpClient())
            {
                string content =await client.GetStringAsync(url);
                Log($"DownloadString/content has {content.Length} chars.",3);
            }
        }
        
        static void Log( string msg,int? seqNum=null)
        {
            string numTtext = seqNum.HasValue ? seqNum.Value.ToString() : string.Empty;
            Console.WriteLine($"{numTtext}\tT[{Thread.CurrentThread.ManagedThreadId}] {msg}");
        }
    }
}