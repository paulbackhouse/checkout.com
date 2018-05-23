using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Checkout.Web.Controllers.Api.v1
{
    using Location;
    using System.Threading.Tasks;

    /// <summary>
    /// Countries REST Api. Endpoints for country specific data
    /// </summary>
    [ApiVersion("1.0")]
    public class CountriesController : BaseApiController
    {
        private ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        /// <summary>
        /// Gets a collection of countries available for order process
        /// </summary>
        /// <returns>Collection of CountryDto</returns>
        [HttpGet]
        public IEnumerable<CountryDto> Get()
            => countryService.Get();

        /// <summary>
        /// Gets a country by a given countryId
        /// </summary>
        /// <param name="countryId">A given country Id to search for</param>
        /// <returns>An instance of a CountryDto, when found</returns>
        [HttpGet("{countryId}")]
        public async Task<CountryDto> Get(short countryId)
            => await countryService.GetByIdAsync(countryId);

    }
}
