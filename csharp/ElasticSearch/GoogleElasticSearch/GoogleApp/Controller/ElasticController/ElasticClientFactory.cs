using System;
using Nest;

namespace GoogleApp.Controller.ElasticController
{

    public class ElasticClientFactory
    {
        private static ElasticClient client = CreateInitialClient();

        private static ElasticClient CreateInitialClient()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();
            return new ElasticClient(connectionSettings);
        }

        public static ElasticClient GetElasticClient()
        {
            return client;
        }
    }
}
