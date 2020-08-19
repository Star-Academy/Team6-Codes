using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

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

        public async void MakeIndex(string index)
        {
            this.index = index;
            var address = BaseAddress + index + "/";
            Console.WriteLine(address);
            try
            {
                HttpResponseMessage response = await client.PutAsync(address, null);
                Console.WriteLine(response.Content);
                // response.EnsureSuccessStatusCode();

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
        public async void RequestPostPeople(List<Person> persons)
        {
            var address = BaseAddress + index + "/_doc";
            foreach (var person in persons)
            {
                var content = JsonContent.Create<Person>(person);
                try
                {
                    HttpResponseMessage response = await client.PostAsync(BaseAddress, content);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(person.About);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody.Length);
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