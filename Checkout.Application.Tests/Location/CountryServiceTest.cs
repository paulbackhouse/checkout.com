using System.Collections.Generic;
using Xunit;

namespace Checkout.Application.Tests.Location
{
    using Checkout.Caching;
    using Checkout.Location;
    using Checkout.Models;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;
    using System.Threading.Tasks;

    public class CountryServiceTest : BaseTest
    {
        private readonly ICountryService service;
        private readonly MemoryCache memCache;
        private readonly ICacheService cache;
        private readonly Mock<ICountryRepository> repo;

        public CountryServiceTest()
        {
            ConfigureMapper();

            memCache = new MemoryCache(new MemoryCacheOptions());
            cache = new MemoryCacheService(new Mock<ILogger<MemoryCacheService>>().Object, memCache);
            repo = new Mock<ICountryRepository>();

            service = new CountryService(cache, repo.Object);
        }

        [Fact]
        public void ItGetsCountries()
        {
            repo.Setup(s => s.GetAsync(true)).ReturnsAsync(Mock.Of<List<CountryEntity>>);
            var results = service.Get();

            Assert.IsType<List<CountryDto>>(results);
            // check cache
            Assert.NotNull(memCache.Get("countries"));
        }

        [Fact]
        public async Task ItGetsById()
        {
            repo.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(Mock.Of<CountryEntity>());
            var result = await service.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.IsType<CountryDto>(result);
        }

    }
}
