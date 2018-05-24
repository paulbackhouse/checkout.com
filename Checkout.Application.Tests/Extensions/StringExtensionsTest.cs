using Xunit;

namespace Checkout.Application.Tests.Extensions
{
    using Checkout.Extensions;

    public class StringExtensionsTest : BaseTest
    {

        public StringExtensionsTest()
        {
        }

        [Fact]
        public void ItDisplaysCurrency()
        {
            decimal value = 1.56M;

            var result = value.AsCurrency("en-Gb");
            Assert.True(string.Compare("£1.56", result).Equals(0));

            result = value.AsCurrency("de-DE");
            Assert.True(string.Compare("1,56 €", result).Equals(0));

        }

    }
}
