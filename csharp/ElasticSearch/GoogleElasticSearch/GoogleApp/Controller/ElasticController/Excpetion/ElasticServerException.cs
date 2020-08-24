namespace GoogleApp.Controller.Excpetion
{
    public class ElasticServerException : System.Exception
    {
        private static string specificMessage = "Server Error happend! \n\n";
        public ElasticServerException(string message) : base(specificMessage + message) { }
    }
}