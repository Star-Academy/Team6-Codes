using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ElasticHttpClient.Model;
namespace ElasticHttpClient.Utils
{
    public class ReadPersonFromFile : ReadPerson
    {
        private readonly string filePath;

        public ReadPersonFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Person> ReadPerson()
        {
            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}