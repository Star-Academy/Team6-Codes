namespace GoogleApp.Controller.Excpetion
{
    public class ElasticException : System.Exception
    {
        public int StatusCode{get; set;}
        public ElasticException(string message) : base(message) { }
    }
}