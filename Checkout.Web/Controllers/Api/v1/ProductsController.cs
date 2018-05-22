using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Checkout.Web.Controllers.Api.v1
{
    using Inventory;
    using System.Threading.Tasks;

    /// <summary>
    /// Product REST Api. Endpoints for product specific data
    /// </summary>
    [ApiVersion("1.0")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets a collection of products available for a given countryId
        /// </summary>
        /// <param name="countryId">A countryId to request products for</param>
        [HttpGet("{countryId}")]
        public IEnumerable<ProductDto> Get(short countryId)
            => productService.Get(countryId);

        /// <summary>
        /// Gets a product by a given productId
        /// </summary>
        /// <param name="productId">Id to query for</param>
        /// <returns>An instance of a ProductDto, when found</returns>
        [HttpGet("{productId}")]
        public async Task<ProductDto> Get(int productId)
            => await productService.GetAsync(productId);

    }
}
