using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Checkout.Location
{
    using Extensions;

    public class CountryDto : BaseDto<short>
    {
        [Required]
        [StringLength(35)]
        public override string Name { get; set; }

        [Required]
        [StringLength(7)]
        public string IsoCode { get; set; }

        public string CurrencySymbol
        {
            get { return new RegionInfo(IsoCode).CurrencySymbol; }
        }

        public string Currency {
            get { return new RegionInfo(IsoCode).ISOCurrencySymbol; }
        }

        [Required]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Tax must be a value between 0 and 100")]
        public decimal Tax { get; set; }

        public string TaxFormatted
        {
            get
            {
                return Tax.AsPercentage();
            }
        }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }
    }
}
