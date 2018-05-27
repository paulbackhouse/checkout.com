using System.Linq;
using Xunit;

namespace Checkout.Application.Tests.Extensions
{
    using Checkout.Extensions;
    using Checkout.Inventory;
    using Checkout.Location;
    using Checkout.Models;
    using Moq;
    using System.Collections.Generic;

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

        [Fact]
        public void ItMapsToPagedResultFirstPage()
        {

            var pager = new PagerDto(0, 1);

            var items = GetPaged(pager);
            var result = items.MapPaged<ProductDto>(pager);

            Assert.Equal(result.Pager.PageIndex, (int)0);
            Assert.Equal(result.Pager.PageSize, (int)1);
            Assert.Equal(result.Pager.Total, (int)5);
            Assert.Equal(result.Pager.PageNumber, (int)1);
            Assert.True(result.Pager.IsFirstPage);
            Assert.False(result.Pager.IsLastPage);

        }

        [Fact]
        public void ItMapsToPagedResultLastPage()
        {

            var pager = new PagerDto(4, 1);

            var items = GetPaged(pager);
            var result = items.MapPaged<ProductDto>(pager);

            Assert.Equal(result.Pager.PageIndex, (int)4);
            Assert.Equal(result.Pager.PageSize, (int)1);
            Assert.Equal(result.Pager.Total, (int)5);
            Assert.Equal(result.Pager.PageNumber, (int)5);
            Assert.False(result.Pager.IsFirstPage);
            Assert.True(result.Pager.IsLastPage);

        }


        IList<ProductEntity> GetPaged(PagerDto pager)
        {
            var lst = new List<ProductEntity>() {
                new Mock<ProductEntity>().Object,
                new Mock<ProductEntity>().Object,
                new Mock<ProductEntity>().Object,
                new Mock<ProductEntity>().Object,
                new Mock<ProductEntity>().Object
            }.AsQueryable();

            return lst.Paged<ProductEntity>(pager).ToList();

        }

    }
}
