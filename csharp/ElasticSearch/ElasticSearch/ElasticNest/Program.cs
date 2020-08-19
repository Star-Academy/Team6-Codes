using System;
using Nest;

namespace ElasticNest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            // DebugMode gives you the request in each request to make debuging easier
            // But don't forget to only use it in debugging, because its usage has some overhead
            // and should not be used in production
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            client.Ping();
            Console.WriteLine(client.Ping());
        }
    }
}
