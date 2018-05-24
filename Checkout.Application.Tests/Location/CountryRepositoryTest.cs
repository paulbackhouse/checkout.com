using Xunit;

namespace Checkout.Application.Tests.Location
{
    using Checkout.Location;
    using System.Linq;
    using System.Threading.Tasks;

    public class CountryRepositoryTest : BaseTest
    {

        private readonly ICountryRepository repo;

        public CountryRepositoryTest()
        {
            MockContext();
            repo = new CountryRepository(context);
        }

        [Fact]
        public async Task ItGetsCountries()
        {
            var count = context.Country.Count(c => c.IsActive == true);

            // active
            var results = await repo.GetAsync(true);
            Assert.Equal(results.Count, count);

            // inactive
            count = context.Country.Count(c => c.IsActive != true);
            results = await repo.GetAsync(false);
            Assert.Equal(results.Count, count);
        }

        [Fact]
        public async Task ItGetsById()
        {
            var result = await repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal(result.Id, (int)1);
        }

    }
}
