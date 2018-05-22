using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Inventory
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a collection of active products by a given country Id reference
        /// </summary>
        /// <param name="countryId">CountryId to return products for</param>
        IList<ProductDto> Get(short countryId);

        /// <summary>
        /// Gets a product by a given Id reference
        /// </summary>
        Task<ProductDto> GetAsync(int id);
    }
}