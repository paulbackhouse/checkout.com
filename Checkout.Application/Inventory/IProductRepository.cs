namespace Checkout.Inventory
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets a paged result of products based on isactive filter (when supplied)
        /// </summary>
        /// <param name="pager">A paging object to return results against</param>
        /// <param name="countryId">Which country to get results for</param>
        /// <param name="isActive">Optional boolean param to indicate whether to retrieve active items by a given state. When empty returns all</param>
        Task<IList<ProductEntity>> GetAsync(PagerDto pager, short countryId, bool? isActive);

        /// <summary>
        /// Gets an instance of product Id by a given Id reference
        /// </summary>
        /// <param name="id">Id reference to search for</param>
        Task<ProductEntity> GetByIdAsync(int id);

    }
}