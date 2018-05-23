using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    public class CartEntity : AuditCreatorModifier
    {
        [Required]
        public Guid CartId { get; set; } = Guid.NewGuid();

        public int ProductId { get; set; }

        public short CountryId { get; set; }

        [Range(1, int.MaxValue)]
        public int Qty { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country{ get; set; }

    }
}
