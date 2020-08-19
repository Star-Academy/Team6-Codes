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
            // post.MakeIndex("http_client");
            await post.RequestPostPeople(readPerson.ReadPerson());
        }
    }
}
