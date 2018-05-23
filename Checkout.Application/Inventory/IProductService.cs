using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Inventory
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a paged collection of active products by a given country Id reference
        /// </summary>
        Task<IList<ProductDto>> GetAsync(PagerDto pager, short countryId);

        /// <summary>
        /// Gets a product by a given Id reference
        /// </summary>
        Task<ProductDto> GetByIdAsync(int id);
    }
}