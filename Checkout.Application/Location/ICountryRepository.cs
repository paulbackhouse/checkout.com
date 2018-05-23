namespace Checkout.Location
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountryRepository
    {
        /// <summary>
        /// Gets a paged result of countries based on isactive filter (when supplied)
        /// </summary>
        /// <param name="isActive">Optional boolean param to indicate whether to retrieve active items by a given state. When empty returns all</param>
        Task<IList<CountryEntity>> GetAsync(bool? isActive);

        /// <summary>
        /// Gets an instance of a country by a given Id reference
        /// </summary>
        /// <param name="id">Country Id</param>
        Task<CountryEntity> GetByIdAsync(short id);
    }
}