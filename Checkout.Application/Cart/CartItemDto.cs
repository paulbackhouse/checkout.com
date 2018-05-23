using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Cart
{
    /// <summary>
    /// an object which defines the minimum requirements for a valid cart item (product)
    /// </summary>
    public class CartItemDto
    {
        public long Id { get; set; }

        public Guid CartId { get; set; } = Guid.Empty;

        [Range(1, short.MaxValue, ErrorMessage = "CountryId must be set")]
        public short CountryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A minimum quantity of 1 must be added")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A min quantity of 1 must be entered")]
        public int Qty { get; set; }
    }
}