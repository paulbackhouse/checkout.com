using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using EntityFramework;
    using Interfaces;
    using Models;

    public class CartRepository : ICartRepository, ITransientService
    {
        private readonly CheckoutContext context;


        public CartRepository(CheckoutContext context)
        {
            this.context = context;
        }


        public async Task<CartEntity> CreateAsync(CartEntity cart)
        {
            await context.Cart.AddAsync(cart);
            await context.SaveChangesAsync();
            return cart;
        }

        public async Task<CartEntity> GetByIdAysnc(Guid cartId)
        {
            return await context.Cart.FirstOrDefaultAsync(f => f.Id == cartId);
        }

        public async Task<IList<CartProductEntity>> GetProductsByIdAysnc(Guid cartId)
        {
            return await context.CartProduct.Include(i => i.Product).ToListAsync();
        }

        public async Task RemoveAsync(Guid cartId)
        {
            // TODO: add soft delete logic here for beta
            var sb = new StringBuilder();
            sb.AppendFormat("delete from CartProduct where CartId = '{0}';", cartId);
            sb.AppendFormat("delete from Cart where CartId = '{0}';", cartId);

            await context.Database.ExecuteSqlCommandAsync(sb.ToString());
            await context.SaveChangesAsync();
        }

        public async Task<CartProductEntity> SaveAsync(CartProductEntity item)
        {
            if (item.Id > 0)
                context.CartProduct.Update(item);

            else
                await context.CartProduct.AddAsync(item);

            await context.SaveChangesAsync();
            return item;
        }


    }
}
