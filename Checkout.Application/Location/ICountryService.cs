using System.Collections.Generic;

namespace Checkout.Location
{
    public interface ICountryService
    {
        /// <summary>
        /// Gets a collection of countries as part of order process
        /// </summary>
        IList<CountryDto> Get();

        /// <summary>
        /// Gets a country by a given Id reference
        /// </summary>
        CountryDto Get(short id);
    }
}