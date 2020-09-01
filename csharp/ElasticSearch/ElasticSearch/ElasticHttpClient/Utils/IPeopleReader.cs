using ElasticHttpClient.Model;
using System.Collections.Generic;

namespace ElasticHttpClient.Utils
{
    public interface IPeopleReader
    {
        List<Person> ReadPeople();
    }
}