using System.Collections.Generic;

namespace Checkout.Inventory
{
    using Models;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets a collection of products based on isactive filter (when supplied)
        /// </summary>
        /// <param name="isActive">Optional boolean param to indicate whether to retrieve active items by a given state. When empty returns all</param>
        IEnumerable<ProductEntity> Get(bool? isActive);

        /// <summary>
        /// Gets an instance of product Id by a given Id reference
        /// </summary>
        /// <param name="id">Id reference to search for</param>
        ProductEntity Get(int id);

    }
}