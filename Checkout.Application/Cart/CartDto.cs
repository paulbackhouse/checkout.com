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
        /// <summary>
        /// An Id of an exiting cart
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// The country Id this cart relates to
        /// </summary>
        public short CountryId { get; set; }

        /// <summary>
        /// The country ISO language code for cart
        /// </summary>
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// The products currently on a cart
        /// </summary>
        public IEnumerable<CartProductDto> Items { get; set; }

        /// <summary>
        /// Total net price of all products (sum)
        /// </summary>
        public decimal TotalNetPrice {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.TotalNetPrice).Round();
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

        /// <summary>
        /// Total tax of all products (sum)
        /// </summary>
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

        /// <summary>
        /// Total gross price of all products (sum)
        /// </summary>
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
