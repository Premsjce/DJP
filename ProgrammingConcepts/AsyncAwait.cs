using System;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts
{
    public class AsyncAwait
    {
        private const string URL = "https://www.codingame.com/playgrounds/4240/your-ultimate-async-await-tutorial-in-c/async-ready-methods-in--net-framework";

        #region Learning on 11th Sep 2021
        public static void Driver()
        {
            DoSomeWorkSynchronously();
            var waitingTask = DoSomeWorkAshyncronously();
            DoSomeWorkSynchronouslyBeforeWaitingTaskIsComplete();
            waitingTask.Wait(); //this becomes a blocking call
            Console.WriteLine("Now the program will exit");
            Console.ReadLine();
        }

        private static void DoSomeWorkSynchronously()
        {
            Console.WriteLine("1. I'm working synchronously");
        }

        private static async Task DoSomeWorkAshyncronously()
        {
            Console.WriteLine("2. I'm working Asynchronously");

            await GetStringIOBoundAsync();
            await GetStringCPUBoundAsync();

        }

        private static async Task GetStringIOBoundAsync()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("3. Awaiting result of getstring async");
                var result = await client.GetStringAsync(URL); //execution pauses here while awaiting getstringasync

                //From this line execution continues only when above task returns value
                Console.WriteLine($"5. The Length of the charactees conunt is  {result.Length}");
            }
        }

        private static async Task GetStringCPUBoundAsync()
        {
            var stringBuilder = new StringBuilder();

            await Task.Run(() =>
            {
                for (int i = 1; i <= 20; i++)
                {
                    Thread.Sleep(100);
                    stringBuilder.Append(i.ToString() + " ");
                }
            });

            //This line gets executed after Task.Run is complted
            Console.WriteLine($"8. {stringBuilder} ");
        }

        private static void DoSomeWorkSynchronouslyBeforeWaitingTaskIsComplete()
        {
            Console.WriteLine("7. I've been called to work before waiting task is complted");
        }



        #endregion

        //#region Archived on 11th September 2021
        //public static void ArchiveDriver()
        //{
        //    ArchiveDoSynchronousWork();
        //    var someTask = ArchiveDoSomethingAsync();
        //    ArchiveDoSynchronousWorkAfterAwait();
        //    someTask.Wait(); //this is a blocking call, use it only on Main method
        //    Console.ReadLine();
        //}

        //public static void ArchiveDoSynchronousWork()
        //{
        //    // You can do whatever work is needed here
        //    Console.WriteLine("1. Doing some work synchronously");
        //}

        //static async Task ArchiveDoSomethingAsync() //A Task return type will eventually yield a void
        //{
        //    Console.WriteLine("2. Async task has started...");
        //    await GetStringAsync(); // we are awaiting the Async Method GetStringAsync
        //}

        //static async Task ArchiveGetStringAsync()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
        //        string result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

        //        //From this line and below, the execution will resume once the above awaitable is done
        //        //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
        //        Console.WriteLine("4. The awaited task has completed. Let's get the content length...");
        //        Console.WriteLine($"5. The length of http Get for {URL}");
        //        Console.WriteLine($"6. {result.Length} character");
        //    }
        //}

        //static void ArchiveDoSynchronousWorkAfterAwait()
        //{
        //    //This is the work we can do while waiting for the awaited Async Task to complete
        //    Console.WriteLine("7. While waiting for the async task to finish, we can do some unrelated work...");
        //    for (var i = 0; i <= 5; i++)
        //    {
        //        for (var j = i; j <= 5; j++)
        //        {
        //            Console.Write("*");
        //        }
        //        Console.WriteLine();
        //    }

        //}
        //#endregion

    }
}
