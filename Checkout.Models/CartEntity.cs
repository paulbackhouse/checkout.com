using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    [Table("Cart")]
    public class CartEntity : BaseEntity<Guid>
    {
        public short CountryId { get; set; }

        [Required]
        public string CountryIsoCode { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }
    }
}
