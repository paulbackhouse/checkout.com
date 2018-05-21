using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Location
{
    using Caching;
    using Interfaces;

    public class CountryService : ICountryService, ITransientService 
    {
        private readonly ICacheService cacheService;

        public CountryService(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public IList<CountryDto> Get()
        {
            return cacheService.Get<List<CountryDto>>(
                "countries",
                new Func<List<CountryDto>>(() =>{
                    // TODO: replace with real country source
                    return new List<CountryDto>()
                    {
                        new CountryDto { Id = 1, Name = "Germany", Tax = 22.5M, IsDefault = true },
                        new CountryDto { Id = 2, Name = "United Kingdom", Tax = 17.5M }
                    };
                }));
        }

        public CountryDto Get(short id)
        {
            return Get().FirstOrDefault(w => w.Id == id);
        }
    }
}
