using System;
using Elasticsearch.Net;
using GoogleApp.Controller.Excpetion;
using Nest;

namespace GoogleApp.Controller.ElasticController
{
    public class ResponseValidator<T> where T : IResponse
    {
        private readonly T response;
        public ResponseValidator(T response)
        {
            this.response = response;

        }
        public void Validate()
        {
            try
            {
                ValidateServerError();
                ValidateClientError();
                ValidateApiError();
            }
            catch (ElasticException e)
            {

                Console.Error.WriteLine(e.Message);
            }
        }

        public void ValidateServerError()
        {
            var error = response.ServerError;
            if (error != null)
                throw new ElasticServerException(error.ToString());
        }

        public void ValidateClientError()
        {
            var error = response.OriginalException;
            if (error != null)
                throw new ElasticClientException(error.Message);
        }

        private void ValidateApiError()
        {
            var error = response.ApiCall.OriginalException;
            if (error != null)
                throw new ElasticApiException(error.Message);
        }
    }
}