using System.ComponentModel.DataAnnotations;

namespace Checkout.Models
{
    using Audit;

    public class ProductEntity : BaseEntity<int>, IActiveState
    {
        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        [Required]
        public short CountryId { get; set; }

        public bool IsActive { get; set; }
    }
}
