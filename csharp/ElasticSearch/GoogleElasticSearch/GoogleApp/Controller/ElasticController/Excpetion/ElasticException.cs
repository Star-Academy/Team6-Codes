namespace GoogleApp.Controller.Excpetion
{
    public class ElasticException : System.Exception
    {
        public ElasticException(string message) : base(message) { }
    }
}