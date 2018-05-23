using System.Globalization;

namespace Checkout.Extensions
{
    public static class StringExtensions
    {

        public static string AsCurrency(this decimal value, string countryIsoCode)
        {
            return string.Format(new CultureInfo(countryIsoCode), "{0:C}", value);
        }

        public static string AsPercentage(this decimal value)
        {
            return string.Format("{0:P2}", (value / 100));
        }
    }
}
