using System.Linq;
using Xunit;

namespace Checkout.Application.Tests.Extensions
{
    using Checkout.Extensions;
    using Checkout.Location;

    public class MapperExtensionsTest : BaseTest
    {

        public MapperExtensionsTest()
        {
            ConfigureMapper();
            MockContext();
        }

        [Fact]
        public void ItMapsAnObject()
        {
            var item = context.Country.First();

            var map = item.Map<CountryDto>();

            Assert.Equal(item.Id, map.Id);
            Assert.Equal(item.IsoCode, map.IsoCode);
            Assert.Equal(item.IsDefault, map.IsDefault);
            Assert.Equal(item.IsActive, map.IsActive);
        }


        [Fact]
        public void ItMapsAList()
        {
            var items = context.Country.ToList();
            var mapped = items.MapList<CountryDto>();

            for (var i = 0; i < mapped.Count; i++)
            {
                Assert.Equal(mapped[i].Id, items[i].Id);
                Assert.Equal(mapped[i].IsoCode, items[i].IsoCode);
                Assert.Equal(mapped[i].IsDefault, items[i].IsDefault);
                Assert.Equal(mapped[i].IsActive, items[i].IsActive);
            }

        }


    }
}
