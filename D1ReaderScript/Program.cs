using System;
using System.IO;
using System.Net.Http;

namespace D1ReaderScript
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)

        {
            while (true)
            {
                await StartListener("http://10.0.0.49/events");
                Console.WriteLine("STARTING");

            }
        }


        public static async System.Threading.Tasks.Task<bool> StartListener(string url)
        {
            using (var client = new HttpClient())
            {
                using (var stream = await client.GetStreamAsync(url))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (true)
                        {
                            if (reader.ReadLine().Contains("message"))
                            { //see if esp sent a specific message. we can encode this 
                                return true;
                            }
                        }
                    }
                }
            }
        }
    }
}
