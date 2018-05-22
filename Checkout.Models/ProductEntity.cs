using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    using Audit;

    [Table("Product")]
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

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }
    }
}
