using System.Collections.Generic;

namespace Checkout.Inventory
{
    using Models;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets a collection of products based on isactive filter (when supplied)
        /// </summary>
        /// <param name="CountryId">Which country to get results for</param>
        /// <param name="isActive">Optional boolean param to indicate whether to retrieve active items by a given state. When empty returns all</param>
        Task<IList<ProductEntity>> GetAsync(short countryId, bool? isActive);

        /// <summary>
        /// Gets an instance of product Id by a given Id reference
        /// </summary>
        /// <param name="id">Id reference to search for</param>
        Task<ProductEntity> GetAsync(int id);

    }
}