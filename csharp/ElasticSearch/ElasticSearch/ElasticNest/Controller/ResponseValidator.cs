using Elasticsearch.Net;

namespace ElasticNest.Controller
{
    public class ResponseValidator<T, R> where T : ElasticsearchResponseBase
    {
        private readonly T response;
        public ResponseValidator(T response)
        {
            this.response = response;
        }


        public bool isValid()
        {
            return response.Success;
        }

        public string getResponseError()
        {
            return response.DebugInformation;
        }
    }
}