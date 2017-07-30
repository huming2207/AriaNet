using System;
using Spooky.Json20;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new JsonRpcHttpClient(new Uri("http://localhost:6800/jsonrpc"));
            var result = client.Invoke<string>("aria2.shutdown").Result;
            Console.WriteLine(result);
        }
    }
}