using System;

namespace Checkout.Application.Exceptions
{
    public class CartException : Exception
    {

        public CartException(string message) : base(message)
        { }

        public CartException(string message, Exception ex) : base(message, ex)
        { }

    }
}
