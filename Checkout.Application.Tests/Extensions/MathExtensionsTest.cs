using System.Linq;
using Xunit;

namespace Checkout.Application.Tests.Extensions
{
    using Checkout.Extensions;
    using Checkout.Location;

    public class MathExtensionsTest : BaseTest
    {

        public MathExtensionsTest()
        {
        }

        [Fact]
        public void ItRounds()
        {
            decimal value = 1.556M;
            var result = value.Round();
            Assert.True(result == 1.56M);

            result = MathExtensions.Round(value, 1);
            Assert.True(result == 1.6M);

            result = MathExtensions.Round(value, 2, System.MidpointRounding.ToEven);
            Assert.True(result == 1.56M);

        }

        [Fact]
        public void ItCalculatesTax()
        {
            decimal value = 100M;
            var result = value.AsTaxAmount(10);

            Assert.True(result == 10);
        }
    }
}
