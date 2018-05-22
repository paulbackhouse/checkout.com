using System;

namespace Checkout.Models
{
    public class CartEntity : BaseEntity<Guid>
    {

        // guest user logic
        // when user authenticated, populate
        public long? UserId { get; set; }

    }
}
