using System;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using Models;
    using System.Collections.Generic;

    public interface ICartRepository
    {

        /// <summary>
        /// Gets a cart for a given Id reference
        /// </summary>
        Task<IList<CartEntity>> Get(Guid cartId);

        /// <summary>
        /// Removes an instance of a cart
        /// </summary>
        Task RemoveAsync(Guid cartId);

        /// <summary>
        /// Removes a product on an existing cart
        /// </summary>
        Task RemoveAsync(Guid cartId, int productId);

        /// <summary>
        /// Saves and cart prouct. Performs Upsert logic based on the existance of unique Id, when 0 add else update
        /// </summary>
        Task<CartEntity> SaveAsync(CartEntity item);
    }
}