using System;
using System.Threading.Tasks;
using ElasticHttpClient.Utils;

namespace ElasticHttpClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var readPerson = new ReadPersonFromFile("/home/mohammadhosein/Desktop/Nest/csharp/ElasticSearch/ElasticSearch/ElasticHttpClient/Data/files.json");
            var post = new PostPerson();
            var tt = Task.Run(() => post.MakeIndex("http_client"));
            tt.Wait();
            var t = Task.Run(() => post.RequestPostPeople(readPerson.ReadPerson()));
            t.Wait();
        }
    }
}
