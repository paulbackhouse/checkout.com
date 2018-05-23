using System;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    public interface ICartService
    {

        /// <summary>
        /// Creates a new cart for a given country Id
        /// </summary>
        Task<CartDto> CreateAsync(short countryId);

        /// <summary>
        /// Gets a cart by a given ID reference
        /// </summary>
        Task<CartDto> GetByIdAsync(Guid cartId);

        /// <summary>
        /// ´Removes a cart and its associated cart items
        /// </summary>
        Task Remove(Guid cartId);

        /// <summary>
        /// Saves an item to a cart, if cart Id is not present a new cart is created with the product added
        /// </summary>
        Task<CartProductDto> SaveAsync(CartProductDto item);
    }
}