using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using EntityFramework;
    using Interfaces;
    using Models;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    public class CartRepository : ICartRepository, ITransientService
    {
        private readonly CheckoutContext context;


        public CartRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<CartEntity>> Get(Guid cartId)
        {
            return await context.Cart
                                .Include(i => i.Product)
                                .Include(i => i.Country)
                                .Where(w => w.CartId == cartId).ToListAsync();
        }

        public async Task<CartEntity> Get(Guid cartId, int productId)
        {
            return await context.Cart
                                .Include(i => i.Product)
                                .Include(i => i.Country)
                                .FirstOrDefaultAsync(f => f.CartId == cartId && f.ProductId == productId);
        }

        public async Task RemoveAsync(Guid cartId)
        {
            // TODO: add soft delete logic here for beta

            // in mem db, for prototype sufficient
            var items = context.Cart.Where(w => w.CartId == cartId);

            context.Cart.RemoveRange(items);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid cartId, int productId)
        {
            context.Cart.Remove(new CartEntity { CartId = cartId, ProductId = productId });
            await context.SaveChangesAsync();
        }

        public async Task<CartEntity> SaveAsync(CartEntity item)
        {
            // TODO: prototype only, EF core does not support AddOrUpdate extension until 2.1
            var existing = await Get(item.CartId, item.ProductId);

            if (existing != null)
            {
                existing.Qty = item.Qty;
                context.Cart.Update(existing);
            }
            else
                // add new
                await context.Cart.AddAsync(item);

            await context.SaveChangesAsync();

            // get the record to ensure price reflects true values with FK relationships in place
            return await Get(item.CartId, item.ProductId);
        }

    }
}
