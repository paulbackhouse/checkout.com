using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Inventory
{
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

        [Required]
        public CountryDto Country { get; set; }

        public decimal Tax
        {
            get {
                if (Country == null)
                    throw new ArgumentNullException($"Country property was not present on Product Code: {Code}");

                return Country.Tax;
            }
        }

        public decimal GrossPrice
        {
            get
            {
                return Math.Round(NetPrice + (NetPrice * Tax / 100), 2, MidpointRounding.AwayFromZero);
            }
        }


        public string GrossPriceFormatted
        {
            get
            {
                return string.Format(new CultureInfo(Country.IsoCode), "{0:C}", GrossPrice);
            }
        }
    }
}
