using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ElasticHttpClient.Model;
namespace ElasticHttpClient.Utils
{
    public class ReadPeopleFromFile : IPeopleReader
    {
        private readonly string filePath;

        public ReadPeopleFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Person> ReadPeople()
        {
            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}