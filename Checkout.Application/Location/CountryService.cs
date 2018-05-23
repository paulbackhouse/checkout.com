using System;
using System.Collections.Generic;

namespace Checkout.Location
{
    using Caching;
    using Extensions;
    using Interfaces;
    using System.Threading.Tasks;

    public class CountryService : ICountryService, ITransientService 
    {
        private readonly ICacheService cacheService;
        private readonly ICountryRepository countryRepository;

        public CountryService(ICacheService cacheService, ICountryRepository countryRepository)
        {
            this.cacheService = cacheService;
            this.countryRepository = countryRepository;
        }

        public IList<CountryDto> Get()
        {
            return cacheService.Get<IList<CountryDto>>(
                "countries",
                new Func<IList<CountryDto>>(() => {
                    // get countries
                    var tsk = countryRepository.GetAsync(true);
                    tsk.Wait();
                    return tsk.Result.MapList<CountryDto>();
                }));

        }

        public async Task<CountryDto> GetByIdAsync(short id)
        {
            var item = await countryRepository.GetByIdAsync(id);
            return item.Map<CountryDto>();
        }
       
    }
}
