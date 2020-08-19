using System;
using ElasticHttpClient.Utils;

namespace ElasticHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var readPerson = new ReadPersonFromFile("Data/files.json");
            var post = new PostPerson();
            // post.MakeIndex("http_client");
            post.RequestPostPeople(readPerson.ReadPerson());
        }
    }
}
