using System.Collections.Generic;
using Xunit;

namespace Checkout.Web.Tests.Controllers.v1
{
    using Checkout.Location;
    using Checkout.Web.Controllers.Api.v1;
    using Moq;
    using System.Threading.Tasks;

    public class CountriesControllerTest
    {

        private readonly Mock<ICountryService> service;
        private readonly CountriesController ctrl;

        public CountriesControllerTest()
        {
            service = new Mock<ICountryService>();
            ctrl = new CountriesController(service.Object);
        }

        [Fact]
        public void ItGetsCountries()
        {
            service.Setup(s => s.Get()).Returns(new List<CountryDto>());
            var result = ctrl.Get();
            Assert.IsType<List<CountryDto>>(result);
        }

        [Fact]
        public async Task ItGetsCountryById()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<short>())).ReturnsAsync(new CountryDto());
            var result = await ctrl.Get(1);
            Assert.IsType<CountryDto>(result);
        }
    }
}
