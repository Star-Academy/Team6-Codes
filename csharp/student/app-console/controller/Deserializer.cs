using System.IO;
using System.Text.Json;

namespace app_console.controller
{
    public class Deserializer<T>
    {

        private string jsonPath;

        public Deserializer(string jsonPath){
            this.jsonPath = jsonPath;
        }

        public T getObject(){
            string scoresJsonText = File.ReadAllText(jsonPath);
            T value = JsonSerializer.Deserialize<T> (scoresJsonText);
            return value;
        }
    }
}