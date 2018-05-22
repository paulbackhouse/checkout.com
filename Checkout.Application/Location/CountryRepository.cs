using System.Collections.Generic;
using System.Linq;

namespace Checkout.Location
{
    using Interfaces;
    using Models;

    /// <summary>
    /// Repository for CRUD country related queries
    /// </summary>
    public class CountryRepository : ICountryRepository, ITransientService
    {
        private readonly IEnumerable<CountryEntity> items;

        public CountryRepository()
        {
            // TODO: replace with valid code here
            //       i.e. real country data
            items = new List<CountryEntity>()
                    {
                        new CountryEntity { Id = 1, Name = "Germany", Tax = 22.5M, IsDefault = true },
                        new CountryEntity { Id = 2, Name = "United Kingdom", Tax = 17.5M }
                    };
        }

        public IEnumerable<CountryEntity> Get(bool? isActive)
        {
            return items.Where(w => isActive == null || w.IsActive == (bool)isActive);
        }

        public CountryEntity Get(short id)
        {
            return items.FirstOrDefault(f => f.Id == id);
        }
    }
}
