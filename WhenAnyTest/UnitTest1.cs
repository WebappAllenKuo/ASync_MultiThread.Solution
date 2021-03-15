using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WhenAnyTest
{
    public class Solution
    {
        /// <summary>
        /// 若指定時限內還沒取得記錄，就傳回null
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> DownloadStringWithTimeount(string url, int timeout)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(url);
                var timeoutTask = Task.Delay(timeout);

                var completedTask = await Task.WhenAny(downloadTask, timeoutTask);
                if (completedTask == timeoutTask)
                {
                    return null;
                }

                return await downloadTask;
            }
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Demo_3秒內沒取回網頁就傳回null_成功()
        {
            string url = "https://www.google.com/";
            int timeout = 3000;
            var sut = new Solution();
            string result = await sut.DownloadStringWithTimeount(url, timeout);
            
            Assert.IsNotNull(result);
            Console.WriteLine($"total char count :{result.Length}");
        }
        
        [Test]
        public async Task Demo_0_01秒內沒取回網頁就傳回null_傳回null()
        {
            string url = "https://www.google.com/";
            int timeout = 1;
            var sut = new Solution();
            string result = await sut.DownloadStringWithTimeount(url, timeout);
            
            Assert.IsNull(result);
            
        }
    }
}