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
        Task<IList<CartEntity>> GetByIdAysnc(Guid cartId);

        /// <summary>
        /// Removes an instance of a cart
        /// </summary>
        Task RemoveAsync(Guid cartId);

        /// <summary>
        /// Saves and cart prouct. Performs Upsert logic based on the existance of unique Id, when 0 add else update
        /// </summary>
        Task<CartEntity> SaveAsync(CartEntity item);
    }
}