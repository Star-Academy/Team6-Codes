using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElasticHttpClient.Model
{
    public class Person
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("eyeColor")]
        public string EyeColor { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("registration_date")]
        public string RegistrationDate { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

    }
}