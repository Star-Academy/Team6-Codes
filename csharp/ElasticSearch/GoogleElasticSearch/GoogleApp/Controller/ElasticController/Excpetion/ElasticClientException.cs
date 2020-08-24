namespace GoogleApp.Controller.Excpetion
{
    public class ElasticClientException : ElasticException
    {
        private static string specificMessage = "Client Error happend! \n\n";
        public ElasticClientException(string message) : base(specificMessage + message) { }

    }
}