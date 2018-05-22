using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    using Audit;

    [Table("Country")]
    public class CountryEntity : BaseEntity<short>, IActiveState
    {
        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [Required]
        [StringLength(7)]
        public string IsoCode { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Tax must be a value between 0 and 100")]
        public decimal Tax { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }
    }
}
