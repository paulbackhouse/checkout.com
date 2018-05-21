using System.ComponentModel.DataAnnotations;

namespace Checkout.Location
{
    public class CountryDto : BaseDto<short>
    {
        [Required]
        [Range(0, 100, ErrorMessage = "Tax must be a value between 0 and 100")]
        public decimal Tax { get; set; }

        public bool IsDefault { get; set; }
    }
}
