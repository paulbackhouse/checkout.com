using Checkout.Web.App.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Web.Controllers.Api.v1
{
    using Cart;

    [ApiVersion("1.0")]
    public class CartController : BaseApiController
    {

        private readonly ICartService cartService;

        public CartController(ICartService cartService) 
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Gets a cart for a given Cart Id reference. 
        /// </summary>
        /// <param name="cartId">string. Unique identifier of a cart</param>
        [HttpGet("{cartId}")]
        public string Get(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
                throw new ApiException("CartId was not supplied");

            return "hey world";
        }

    }
}
