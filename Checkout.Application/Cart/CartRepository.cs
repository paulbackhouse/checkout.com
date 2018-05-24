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

        public async Task<IList<CartEntity>> GetAsync(Guid cartId)
        {
            return await context.Cart
                                .Include(i => i.Product)
                                .Include(i => i.Country)
                                .Where(w => w.CartId == cartId).ToListAsync();
        }

        public async Task<CartEntity> GetAsync(Guid cartId, int productId)
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
            // TODO: for purposes of prototype this approach is acceptable
            var match = await context.Cart.FirstOrDefaultAsync(f => f.CartId == cartId && f.ProductId == productId);

            if (match != null)
            {
                context.Cart.Remove(match);
                await context.SaveChangesAsync();
            }
        }

        public async Task<CartEntity> SaveAsync(CartEntity item)
        {
            // TODO: prototype only, EF core does not support AddOrUpdate extension until 2.1
            var existing = await GetAsync(item.CartId, item.ProductId);

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
            return await GetAsync(item.CartId, item.ProductId);
        }

    }
}
