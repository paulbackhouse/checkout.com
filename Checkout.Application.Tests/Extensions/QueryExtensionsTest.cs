using System.Linq;
using Xunit;

namespace Checkout.Application.Tests.Extensions
{
    using Checkout.Extensions;
    using Checkout.Location;
    using System.Collections.Generic;

    public class QueryExtensionsTest : BaseTest
    {

        public QueryExtensionsTest()
        {
        }

        [Fact]
        public void ItPagesAQueryable()
        {
            var lst = new List<CountryDto>();

            for (var i = 0; i < 11; i++)
                lst.Add( new CountryDto { Id = (short)i });

            var results = lst.AsQueryable().Paged(new PagerDto(0, 2));

            Assert.True(results.Count() == 2);

            results = lst.AsQueryable().Paged(new PagerDto(1, 3));

            Assert.True(results.Count() == 3);
        }

    }
}
