using System.Collections.Generic;
using ElasticNest.Models;

namespace ElasticNest.Utils
{
    public interface IReader<T>
    {
        T ReadPerson();
    }
}