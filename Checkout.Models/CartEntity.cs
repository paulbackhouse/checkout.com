using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Models
{
    [Table("Cart")]
    public class CartEntity : BaseEntity<Guid>
    {

        // guest user logic
        // when user authenticated, populate
        public long? UserId { get; set; }

    }
}
