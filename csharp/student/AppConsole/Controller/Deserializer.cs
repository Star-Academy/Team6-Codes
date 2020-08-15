using System.IO;
using System.Text.Json;

namespace AppConsole.Controller
{
    public class Deserializer<T>
    {

        private readonly string jsonPath;

        public Deserializer(string jsonPath)
        {
            this.jsonPath = jsonPath;
        }

        public T GetObject()
        {
            string scoresJsonText = File.ReadAllText(jsonPath);
            T value = JsonSerializer.Deserialize<T>(scoresJsonText);
            return value;
        }
    }
}