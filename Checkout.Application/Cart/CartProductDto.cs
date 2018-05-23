namespace Checkout.Cart
{
    using Inventory;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CartProductDto
    {
        public long Id { get; set; }

        public Guid CartId { get; set; }

        public short CountryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A minimum quantity of 1 must be added")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A min quantity of 1 must be entered")]
        public int Qty { get; set; }

        public decimal NetPrice { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalNetPrice
        {
            get
            {
                return Math.Round(Qty * NetPrice, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal TotalTax
        {
            get
            {
                return Math.Round(Qty * TaxAmount, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal TotalGrossPrice
        {
            get
            {
                return Math.Round(TotalNetPrice + TotalTax, MidpointRounding.AwayFromZero);
            }
        }
    }
}
