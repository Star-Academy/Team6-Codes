namespace GoogleApp.Controller.Excpetion
{
    public class ElasticServerException : ElasticException
    {
        private static string specificMessage = "Server Error happend! \n\n";
        public ElasticServerException(string message) : base(specificMessage + message)
        {
            this.StatusCode = 503;
        }
    }
}