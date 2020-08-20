using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ElasticHttpClient.Model;

namespace ElasticHttpClient.Utils
{
    public class PostPerson
    {
        HttpClient client { get; set; }
        private readonly string BaseAddress = "http://localhost:9200/";
        private string index;
        public PostPerson()
        {
            client = new HttpClient();
        }

        public async Task MakeIndex(string index)
        {
            this.index = index;
            var address = BaseAddress + index + "/";
            Console.WriteLine(address);
            try
            {
                var response = await client.PutAsync(address, null);
                Console.WriteLine(response.Content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.StackTrace);
            }
        }
        public async Task RequestPostPeople(List<Person> people)
        {
            var address = BaseAddress + index + "/_doc";
            var uri = new Uri(address);
            foreach (var person in people)
            {
                var content = JsonContent.Create<Person>(person);
                try
                {
                    HttpResponseMessage response = await client.PostAsync(uri, content);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    Console.WriteLine(e.Data);
                    Console.WriteLine(e.StackTrace);
                }
            }

        }
    }
}