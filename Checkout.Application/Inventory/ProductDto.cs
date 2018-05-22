using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Checkout.Inventory
{
    using Location;

    public class ProductDto : BaseDto<int>
    {
        [Required]
        [StringLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        [Required]
        public CountryDto Country { get; set; }

        public decimal GrossPrice
        {
            get
            {
                return NetPrice + (Country.Tax / 100);
            }
        }
    }
}
