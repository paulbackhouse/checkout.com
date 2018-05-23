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
        /// <param name="pageIndex">Zero based index querystring parameter requesting page. Default 0 (first page)</param>
        /// <param name="pageSize">Page size querystring parameter required. Default 15</param>
        [HttpGet("{countryId}")]
        public async Task<IEnumerable<ProductDto>> Get(short countryId, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = Constants.DefaultPageSize)
            => await productService.GetAsync(new PagerDto(pageIndex, pageSize), countryId);

        /// <summary>
        /// Gets a product by a given productId
        /// </summary>
        /// <param name="productId">Id to query for</param>
        /// <returns>An instance of a ProductDto, when found</returns>
        [HttpGet("{productId}")]
        public async Task<ProductDto> Get(int productId)
            => await productService.GetByIdAsync(productId);

    }
}
