using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ElasticNest.Models;

namespace ElasticNest.Utils
{
    public class JsonReader<T> : IReader<T>
    {

        private readonly string filePath;


        public JsonReader(string filePath)
        {
            this.filePath = filePath;
        }
        public T ReadPerson()
        {
            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}