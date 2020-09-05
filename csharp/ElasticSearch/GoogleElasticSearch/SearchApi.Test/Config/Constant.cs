using System;
using System.Net;

namespace SearchApi.Config
{
    public class Constant
    {
        public static readonly string trueQuery = "hello +world -mahdi";
        public static readonly string serverErrorQuery = "bye -mhm";
        public static readonly string clientErrorQuery = "reza";
        public static readonly string apiErrorQuery = "mohamadhosein";
        public static readonly int serverErrorStatusCode = Int32.Parse(HttpStatusCode.ServiceUnavailable.ToString());
        public static readonly int clientErrorStatusCode = Int32.Parse(HttpStatusCode.ServiceUnavailable.ToString());
        public static readonly int apiErrorStatusCode = Int32.Parse(HttpStatusCode.ServiceUnavailable.ToString());
    }
}