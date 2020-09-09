using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace CleanCode
{
    public class AsynchronousCoding
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp/csharp";

        public static void Driver()
        {
            DoSynchronousWork();
            var someTask = DoSomethingAsync();
            DoSynchronousWorkAfterAwait();

            var calcTask = CalulateTaxAsync(5.5f);

            calcTask.Wait(); //this is a blocking call, use it only on Main method

            DoSynchronousWorkAfterAwait();
            someTask.Wait();

            Console.ReadLine();
        }

        public static void DoSynchronousWork() => Console.WriteLine("1. First Call of Synchronous working");

        private static async Task<int> DoSomethingAsync()
        {
            Console.WriteLine($"2. Async task has started...");
            var stringtask =  await GetStringAsync(); // we are awaiting the Async Method GetStringAsync

            //task.Wait();
            var stringLength = 0;
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine($"3. Awaiting the result of GetStringAsync of Http Client...");

                string result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine($"4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {URL}");
                Console.WriteLine($"6. {result.Length} character");
                stringLength = result.Length;
            }

            return stringLength;
        }

        private async static Task<int> GetStringAsync()
        {
            var strLengt = 0;
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");

                string result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine($"4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {URL}");
                Console.WriteLine($"6. {result.Length} character");
                strLengt = result.Length;
            }

            return strLengt;
        }

        private static void DoSynchronousWorkAfterAwait()
        {
            //This is what we will be doing while waiting for the awaited async task to complete
            Console.WriteLine($"7. Second Call of Synchronous working");

            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }


        }

        private static async Task<float> CalulateTaxAsync(float value)
        {
            Console.WriteLine("Started CPU bound calulcationsm which runs in background worker thread");
            var result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return value * 1.2f;
            });

            Console.WriteLine($"Finished Task. Total of ${value} after tax of 20% is ${result} ");
            return result;

        }

        public static void AsyncDriver()
        {
            AsyncSample asyncSample = new AsyncSample();
            Console.WriteLine("Before calling async method");


            var task = asyncSample.PrintFullNameAsync("Prem", "Reddy");

            Console.WriteLine("After calling async method");

            asyncSample.GetFullNameSync("Sync", "Code");

            task.Wait();
            Console.ReadLine();
        }
    }

    public class AsyncSample
    {
        public async Task PrintFullNameAsync(string fName, string lName)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(500);
                    var name = $"{fName} {lName}";
                    Console.WriteLine(name);
                }
                return "some code";
            });
        }

        public void GetFullNameSync(string fName, string lName)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(fName + " " + lName);
            }
        }
    }


}
