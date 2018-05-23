using Checkout.Web.App.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Web.Controllers.Api.v1
{
    using Cart;
    using Exceptions;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class CartController : BaseApiController
    {

        private readonly ICartService cartService;

        public CartController(ICartService cartService) 
        {
            this.cartService = cartService;
        }


        [HttpPost]
        public async Task<CartDto> Create(short countryId)
            => await cartService.CreateAsync(countryId);


        /// <summary>
        /// Gets a cart for a given Cart Id reference. 
        /// </summary>
        /// <param name="cartId">string. Unique identifier of a cart</param>
        [HttpGet("{cartId}")]
        public async Task<CartDto> Get(Guid cartId)
        {
            ValidateCartId(cartId);
            return await cartService.GetByIdAsync(cartId);
        }

        /// <summary>
        /// Add or updates a cart item. When Cart Id is not provided a new cart is created
        /// </summary>
        /// <param name="item">An object containing product information to add to a new or existing cart</param>
        [HttpPut]
        public async Task<CartProductDto> Save(CartProductDto item)
            => await cartService.SaveAsync(item);


        /// <summary>
        /// Removes and instance of a cart object and associated items
        /// </summary>
        [HttpDelete("{cartId}")]
        public async Task Remove(Guid cartId)
        {
            ValidateCartId(cartId);
            await cartService.Remove(cartId);
        }

        void ValidateCartId(Guid cartId)
        {
            if (cartId.Equals(Guid.Empty))
                throw new CartException("CartId was not supplied");
        }

    }
}
