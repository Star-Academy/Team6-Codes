using System;
using Elasticsearch.Net;
namespace GoogleApp.Controller.ElasticController
{
    public class ResponseValidator<T> where T : IElasticsearchResponse
    {
        private readonly T response;
        public ResponseValidator(T response)
        {
            this.response = response;
            if(!isValid())
                Console.WriteLine(getResponseError());
        }

        public bool isValid()
        {
            return response.ApiCall.Success;
        }

        public string getResponseError()
        {
            return response.ApiCall.DebugInformation;
        }
    }
}