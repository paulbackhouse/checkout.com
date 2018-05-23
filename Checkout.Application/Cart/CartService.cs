using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Location;
    using Models;

    public class CartService : ICartService, ITransientService
    {
        // members
        private readonly ILogger<CartService> logger;
        private readonly ICartRepository cartRepository;
        private readonly ICountryService countryService;


        public CartService(ILogger<CartService> logger, ICartRepository cartRepository, ICountryService countryService)
        {
            this.logger = logger;
            this.cartRepository = cartRepository;
            this.countryService = countryService;
        }

        public async Task<CartDto> GetByIdAsync(Guid cartId)
        {
            try
            {
                var cart = await cartRepository.GetByIdAysnc(cartId);
                return Map(cart);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to retrieve cart Id {0}", cartId);
                throw new CartException("Unable to retrieve the cart you have requested. Check the Id. Our development team have been notified");
            }
        }

        public async Task Remove(Guid cartId)
        {
            try
            {
                logger.LogDebug("Deleting cart {0}", cartId);
                await cartRepository.RemoveAsync(cartId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to remove cart Id {0}", cartId);
                throw new CartException("Unable to delete the cart. An unexpected error has occured. Our development team have been made aware");
            }
        }

        public async Task Remove(Guid cartId, int productId)
        {
            try
            {
                logger.LogDebug("Deleting item from cart {0} for product {1}", cartId, productId);
                await cartRepository.RemoveAsync(cartId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to remove cart Id {0}", cartId);
                throw new CartException("Unable to delete the cart. An unexpected error has occured. Our development team have been made aware");
            }
        }

        public async Task<CartProductDto> SaveAsync(CartItemDto item)
        {
            try
            {
                if (item.CartId.Equals(Guid.Empty))
                {
                    // is new cart
                    item.CartId = Guid.NewGuid();
                }

                // save the product for a cart
                var map = item.Map<CartEntity>();
                var result = await cartRepository.SaveAsync(map);
                return result.Map<CartProductDto>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to save cart item for cart Id {0}, product Id {1}, Qty {2}", item.CartId, item.ProductId, item.Qty);
                throw new CartException($"Unable to save product to cart Id {item.CartId}");
            }
        }

        CartDto Map(IEnumerable<CartEntity> cart)
        {
            var map = cart.Map<CartDto>();
            map.Items = cart.Map<IList<CartProductDto>>();
            return map;
        }
    }
}
