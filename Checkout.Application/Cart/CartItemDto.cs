using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Cart
{
    /// <summary>
    /// an object which defines the minimum requirements for a valid cart item (product)
    /// </summary>
    public class CartItemDto
    {
        /// <summary>
        /// Unique Id of an existing cart to update. 
        /// When empty a new cart is create (Guid.Empty = 00000000-0000-0000-0000-000000000000)
        /// </summary>
        public Guid CartId { get; set; } = Guid.Empty;

        /// <summary>
        /// Country the cart item relates to
        /// </summary>
        [Required]
        [Range(1, short.MaxValue, ErrorMessage = "CountryId must be set")]
        public short CountryId { get; set; }

        /// <summary>
        /// Cart item (product) to add/update
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A minimum quantity of 1 must be added")]
        public int ProductId { get; set; }

        /// <summary>
        /// the quantity to add/update for a given cart item (product)
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A min quantity of 1 must be entered")]
        public int Qty { get; set; }
    }
}