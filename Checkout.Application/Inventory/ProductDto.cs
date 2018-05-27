using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Inventory
{
    using Exceptions;
    using Extensions;
    using Location;
    using System.Globalization;

    /// <summary>
    /// an object describing a product available as part of a cart
    /// </summary>
    public class ProductDto : BaseDto<int>
    {
        /// <summary>
        /// Unique code for  product
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        public string NetPriceFormatted
        {
            get
            {
                return string.Format(new CultureInfo(Country.IsoCode), "{0:C}", NetPrice);
            }
        }

        /// <summary>
        /// Related country product is available for
        /// </summary>
        [Required]
        public CountryDto Country { get; set; }

        /// <summary>
        /// Tax amount for product (based on country)
        /// </summary>
        public decimal TaxAmount {
            get
            {
                if (Country == null)
                    throw new CartException($"A country was not available for product code: {Code}");

                return NetPrice.AsTaxAmount(Country.Tax);
            }
        }

        public string TaxAmountFormatted
        {
            get
            {
                return string.Format(new CultureInfo(Country.IsoCode), "{0:C}", TaxAmount);
            }
        }
    }
}
