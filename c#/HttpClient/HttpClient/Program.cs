using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientBenchmark
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await synchAverage(1);
            await asynchAverage(1);
            await synchAverage(10);
            await asynchAverage(10);
            await synchAverage(100);
            await asynchAverage(100);
        }

        static async Task<int> SingleRequest()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                HttpResponseMessage response = await client.GetAsync("http://www.httpbin.org/get");
                stopWatch.Stop();

                return (int)stopWatch.ElapsedMilliseconds;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                return -1;
            }
        }

        static async Task<int> synchAverage(int n)
        {
            Task<int>[] tasks = new Task<int>[n];

            for (int i = 0; i < n; i++)
            {
                tasks[i] = SingleRequest();
            }

            int total = 0;
            await Task.WhenAll(tasks);

            for (int i = 0; i < n; i++)
            {
                total += tasks[i].Result;
            }

            int average = total / n;

            Console.WriteLine("Average response time over " + n + " synchronous request:" + average);

            return average;
        }

        static async Task asynchAverage(int n)
        {
            Task<int>[] tasks = new Task<int>[n];

            int total = 0;

            for (int i = 0; i < n; i++)
            {
                tasks[i] = SingleRequest();
                total += await SingleRequest();
            }

            int average = total / n;

            Console.WriteLine("Average response time over " + n + " asynchronous request:" + average);
        }
    }
}
