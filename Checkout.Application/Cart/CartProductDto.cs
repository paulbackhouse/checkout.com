using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Cart
{
    using Extensions;

    /// <summary>
    /// an oject describing a logical product as part of a cart
    /// </summary>
    public class CartProductDto : CartItemDto
    {
        public string CountryIsoCode { get; set; }

        public decimal NetPrice { get; set; }

        public decimal TotalNetPrice
        {
            get
            {
                return (Qty * NetPrice).Round();
            }
        }

        public string TotalNetPriceFormatted
        {
            get
            {
                return TotalNetPrice.AsCurrency(CountryIsoCode);
            }
        }

        public decimal TaxAmount { get; set; }

        public decimal TotalTax
        {
            get
            {
                return (Qty * TaxAmount).Round();
            }
        }

        public string TotalTaxFormatted
        {
            get
            {
                return TotalTax.AsCurrency(CountryIsoCode);
            }
        }

        public decimal TotalGrossPrice
        {
            get
            {
                return (TotalNetPrice + TotalTax).Round();
            }
        }

        public string TotalGrossPriceFormatted
        {
            get
            {
                return TotalGrossPrice.AsCurrency(CountryIsoCode);
            }
        }

    }
}
