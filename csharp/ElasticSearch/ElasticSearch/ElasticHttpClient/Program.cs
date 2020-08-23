using System.Threading.Tasks;
using ElasticHttpClient.Utils;

namespace ElasticHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var readPerson = new ReadPeopleFromFile("Data/files.json");
            var post = new PostPerson();
            var tt = Task.Run(() => post.MakeIndex("http_client"));
            tt.Wait();
            var t = Task.Run(() => post.RequestPostPeople(readPerson.ReadPeople()));
            t.Wait();
        }
    }
}
