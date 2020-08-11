using System.IO;
using System.Text.Json;

namespace AppConsole.Controller
{
    public class Deserializer<T>
    {

        private string JsonPath;

        public Deserializer(string jsonPath){
            this.JsonPath = jsonPath;
        }

        public T GetObject(){
            string scoresJsonText = File.ReadAllText(JsonPath);
            T value = JsonSerializer.Deserialize<T> (scoresJsonText);
            return value;
        }
    }
}