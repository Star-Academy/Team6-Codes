using Elasticsearch.Net;

namespace ElasticNest.Controller
{
    public class ResponseValidator<T> where T : IElasticsearchResponse
    {
        private readonly T response;
        public ResponseValidator(T response)
        {
            this.response = response;
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