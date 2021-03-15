using System;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace AsyncExec
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Main start.");

            string url = "http://www.google.com/";
            DownloadString(url);
            
            Log("Main end.");
        }

        static void DownloadString(string url)
        {
            using (var client =new WebClient())
            {
                string content = client.DownloadString(url);
                Log($"DownloadString/content has {content.Length} chars.");
            }
        }
        static void Log( string msg,int? seqNum=null)
        {
            string numTtext = seqNum.HasValue ? seqNum.Value.ToString() : string.Empty;
            Console.WriteLine($"{numTtext}\tT[{Thread.CurrentThread.ManagedThreadId}] {msg}");
        }
    }
}