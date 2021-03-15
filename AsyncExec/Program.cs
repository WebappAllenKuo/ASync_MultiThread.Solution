using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExec
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log("Main start.",1); // 1. start

            string url = "http://www.google.com/";
            DownloadStringAsync(url).Wait(); // 1.1. 非同步;但由於Wait()是會等待這個非同步結束才會向下，所以主程式在此會停住

            Log("Main end.", 3); // 3. 程式緊接著執行這裡
            
            // await Task.Delay(3000); // 3. 持續等待3 seconds
            
            //5. 結束 main()
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
                // 2. 擷取完畢，接著執行下面程式
                Log($"DownloadString/content has {content.Length} chars.",2);
            }
        }
        
        static void Log( string msg,int? seqNum=null)
        {
            string numTtext = seqNum.HasValue ? seqNum.Value.ToString() : string.Empty;
            Console.WriteLine($"{numTtext}\tT[{Thread.CurrentThread.ManagedThreadId}] {msg}");
        }
    }
}