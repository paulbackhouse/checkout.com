using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Checkout.Web.Controllers.Api.v1
{
    using Location;

    /// <summary>
    /// Product REST Api. Endpoints for product specific data
    /// </summary>
    [ApiVersion("1.0")]
    public class ProductsController : BaseApiController
    {

        public ProductsController()
        {
        }

        /// <summary>
        /// Gets a collection of products available for a given countryId
        /// </summary>
        /// <param name="countryId">A countryId to request products for</param>
        /// <returns></returns>
        //[HttpGet("{countryId}")]
        //public IEnumerable<CountryDto> Get(short countryId)
        //    => countryService.Get();

    }
}
