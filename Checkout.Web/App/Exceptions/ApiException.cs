using System;
using System.Net;

namespace Checkout.Web.App.Exceptions
{
    public class ApiException : Exception
    {
        private readonly HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        public HttpStatusCode HttpStatusCode => httpStatusCode;


        public ApiException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public ApiException(string message, Exception innerException, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message, innerException)
        {
            this.httpStatusCode = httpStatusCode;
        }

    }
}
