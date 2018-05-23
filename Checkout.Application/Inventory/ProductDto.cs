using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Inventory
{
    using Exceptions;
    using Location;
    using System.Globalization;

    public class ProductDto : BaseDto<int>
    {

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

        [Required]
        public CountryDto Country { get; set; }

        public decimal TaxAmount {
            get
            {
                if (Country == null)
                {
                    throw new CartException($"A country was not available for product code: {Code}");
                }

                return Math.Round((Country.Tax / 100) * NetPrice, 2, MidpointRounding.AwayFromZero);
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
