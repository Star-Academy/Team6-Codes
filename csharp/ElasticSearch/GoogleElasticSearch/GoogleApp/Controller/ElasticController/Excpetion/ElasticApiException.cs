namespace GoogleApp.Controller.Excpetion
{
    public class ElasticApiException : ElasticException
    {
        private static string specificMessage = "your requested api is not correct! \n\n";
        public ElasticApiException(string message) : base(specificMessage + message) { 
            this.StatusCode = 400;
        }

    }
}