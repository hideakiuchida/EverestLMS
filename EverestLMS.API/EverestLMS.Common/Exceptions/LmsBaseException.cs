using System;

namespace EverestLMS.Common.Exceptions
{
    public class LmsBaseException : Exception
    {
        public int StatusCode { get; set; }
        public LmsBaseException(string message) : base(message)
        {
            
        }

        public LmsBaseException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
