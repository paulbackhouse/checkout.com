using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Location
{
    public interface ICountryService
    {
        /// <summary>
        /// Gets a collection of active countries as part of order process
        /// </summary>
        IList<CountryDto> Get();

        /// <summary>
        /// Gets a country by a given Id reference
        /// </summary>
        Task<CountryDto> GetByIdAsync(short id);
    }
}