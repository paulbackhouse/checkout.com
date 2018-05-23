using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    public class CartProductEntity : BaseEntity<long>
    {
        [Required]
        public Guid CartId { get; set; }

        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Qty { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
    }
}
