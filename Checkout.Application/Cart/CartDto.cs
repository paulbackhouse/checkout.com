using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Cart
{
    using Extensions;

    /// <summary>
    /// an object describing a logic cart and items currently associated
    /// </summary>
    public class CartDto
    {
        public Guid Id { get; set; }

        public short CountryId { get; set; }

        public string CountryIsoCode { get; set; }

        public IEnumerable<CartProductDto> Items { get; set; }

        public decimal TotalNetPrice {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.NetPrice).Round();
                }

                return 0;
            }
        }

        public string TotalNetPriceFormatted
        {
            get
            {
                return TotalNetPrice.AsCurrency(CountryIsoCode);
            }
        }

        public decimal TotalTax {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.TotalTax).Round();
                }

                return 0;
            }
        }

        public string TotalTaxFormatted
        {
            get
            {
                return TotalTax.AsCurrency(CountryIsoCode);
            }
        }

        public decimal TotalGrossPrice {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.TotalGrossPrice).Round();
                }

                return 0;
            }
        }

        public string TotalGrossPriceFormatted
        {
            get
            {
                return TotalGrossPrice.AsCurrency(CountryIsoCode);
            }
        }

    }
}
