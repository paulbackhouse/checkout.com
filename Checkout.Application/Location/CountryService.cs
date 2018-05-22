using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Location
{
    using Caching;
    using Interfaces;
    using Models;

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
            return cacheService.Get<List<CountryDto>>(
                "countries",
                new Func<IList<CountryDto>>(() =>{
                    // TODO: replace with real country source
                    var result = countryRepository.Get(true);
                    return Map(result);
                }));
        }

        public CountryDto Get(short id)
        {
            return Get().FirstOrDefault(w => w.Id == id);
        }

        IList<CountryDto> Map(IEnumerable<CountryEntity> items)
        {
            var lst = new List<CountryDto>();

            // TODO: replace with automapper
            foreach (var item in items)
            {
                lst.Add(new CountryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsDefault = item.IsDefault,
                    Tax = item.Tax,
                    IsActive = item.IsActive
                });
            }

            return lst;
        }
    }
}
