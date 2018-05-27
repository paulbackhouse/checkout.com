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

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        /// <summary>
        /// Country ISO language code
        /// </summary>
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// Singular price of product
        /// </summary>
        public decimal NetPrice { get; set; }

        /// <summary>
        /// Total net price by product and quantity
        /// </summary>
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

        /// <summary>
        /// Singular tax amount for product (by country)
        /// </summary>
        public decimal TaxAmount { get; set; }

        public string TaxAmountFormatted
        {
            get
            {
                return TaxAmount.AsCurrency(CountryIsoCode);
            }
        }

        /// <summary>
        /// Total tax by country, product and quantity
        /// </summary>
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

        /// <summary>
        /// Total gross price for product, the sum of total net price an total tax
        /// </summary>
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
