using System;

namespace Checkout.Extensions
{
    public static class MathExtensions
    {

        public static decimal Round(this decimal value, int decimals = 2, MidpointRounding midpointRounding = MidpointRounding.AwayFromZero)
        {
            return Math.Round(value, decimals, midpointRounding);
        }

        public static decimal AsTaxAmount(this decimal netValue, decimal taxValue)
        {
            return ((taxValue / 100) * netValue).Round();
        }


    }
}
