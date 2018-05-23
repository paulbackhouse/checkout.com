using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Cart
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class CartDto
    {
        public Guid Id { get; set; }

        public short CountryId { get; set; }

        [Required]
        public string CountryIsoCode { get; set; }

        public IEnumerable<CartProductDto> Items { get; set; }

        public decimal TotalNetPrice {
            get
            {
                if (Items != null)
                {
                    return Math.Round(Items.Sum(s => s.NetPrice), 2, MidpointRounding.AwayFromZero);
                }

                return 0;
            }
        }

        public string TotalNetPriceFormatted
        {
            get
            {
                return string.Format(new CultureInfo(CountryIsoCode), "{0:C}", TotalNetPrice);
            }
        }

        public decimal TotalTax {
            get
            {
                if (Items != null)
                {
                    return Math.Round(Items.Sum(s => s.TotalTax), 2, MidpointRounding.AwayFromZero);
                }

                return 0;
            }
        }

        public string TotalTaxFormatted
        {
            get
            {
                return string.Format(new CultureInfo(CountryIsoCode), "{0:C}", TotalTax);
            }
        }

        public decimal TotalGrossPrice {
            get
            {
                if (Items != null)
                {
                    return Math.Round(Items.Sum(s => s.TotalGrossPrice), 2, MidpointRounding.AwayFromZero);
                }

                return 0;
            }
        }

        public string GrossPriceFormatted
        {
            get
            {
                return string.Format(new CultureInfo(CountryIsoCode), "{0:C}", TotalGrossPrice);
            }
        }

    }
}
