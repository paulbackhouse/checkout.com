using System;

namespace Checkout.Models
{
    public class AuditCreatorModifier
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public long? CreatorId { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;

        public long? ModifierId { get; set; }
    }
}
