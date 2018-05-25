using Microsoft.AspNetCore.Mvc;

namespace Checkout.Web.Controllers.Api.v1
{
    using Cart;
    using Exceptions;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Cart REST Api. Endpoints for cart specific logic
    /// </summary>
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
        public async Task<CartDto> Get(Guid cartId)
        {
            ValidateCartId(cartId);
            return await cartService.GetByIdAsync(cartId);
        }

        /// <summary>
        /// Adds an item to a cart. A new cart is created if cartId is not specified on the item
        /// </summary>
        /// <param name="item">An object containing product information to add to a new or existing cart</param>
        [HttpPut]
        public async Task<CartProductDto> Save(CartItemDto item)
            => await cartService.SaveAsync(item);


        /// <summary>
        /// Removes and instance of a cart object and associated items
        /// </summary>
        /// <param name="cartId">Id reference to delete all items and cart</param>
        [HttpDelete("{cartId}")]
        public async Task Remove(Guid cartId)
        {
            ValidateCartId(cartId);
            await cartService.RemoveAsync(cartId);
        }

        /// <summary>
        /// Removes a cart item for a given cartId and productId
        /// </summary>
        /// <param name="cartId">CartId reference to delete a product against</param>
        /// <param name="productId">ProductId reference to delete from a given cartId reference</param>
        [HttpDelete("{cartId}/{productId}")]
        public async Task Remove(Guid cartId, int productId)
        {
            ValidateCartId(cartId);
            await cartService.RemoveAsync(cartId, productId);
        }

        void ValidateCartId(Guid cartId)
        {
            if (cartId.Equals(Guid.Empty))
                throw new CartException("CartId was not supplied");
        }

    }
}
