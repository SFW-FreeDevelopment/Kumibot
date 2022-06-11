using System.Net;

namespace Kumibot.Exceptions;

public class KumibotException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    
    public KumibotException () {}

    public KumibotException(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }
}