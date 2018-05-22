using System.Collections.Generic;

namespace Checkout.Location
{
    using Models;

    public interface ICountryRepository
    {
        /// <summary>
        /// Gets a collection of countries based on isactive filter (when supplied)
        /// </summary>
        /// <param name="isActive">Optional boolean param to indicate whether to retrieve active items by a given state. When empty returns all</param>
        IEnumerable<CountryEntity> Get(bool? isActive);

        /// <summary>
        /// Gets an instance of a country by a given Id reference
        /// </summary>
        /// <param name="id">Country Id</param>
        /// <returns></returns>
        CountryEntity Get(short id);
    }
}