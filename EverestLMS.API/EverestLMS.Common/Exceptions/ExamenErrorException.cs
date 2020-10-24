using System;

namespace EverestLMS.Common.Exceptions
{
    public class ExamenErrorException : Exception
    {
        public int StatusCode { get; set; }
        public ExamenErrorException(string message) : base(message)
        {
            
        }

        public ExamenErrorException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
