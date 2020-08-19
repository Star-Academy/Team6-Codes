using ElasticHttpClient.Model;
using System.Collections.Generic;

namespace ElasticHttpClient.Utils
{
    public interface ReadPerson
    {
        List<Person> ReadPerson();
    }
}