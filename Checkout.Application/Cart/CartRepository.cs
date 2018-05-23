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
    using System.Data.SqlClient;
    using System.Linq;

    public class CartRepository : ICartRepository, ITransientService
    {
        private readonly CheckoutContext context;


        public CartRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<CartEntity>> GetByIdAysnc(Guid cartId)
        {
            return await context.Cart.Where(w => w.CartId == cartId).ToListAsync();
        }

        public async Task RemoveAsync(Guid cartId)
        {
            // TODO: add soft delete logic here for beta
            //var sb = new StringBuilder();

            //sb.Append("delete from Cart where CartId = @cartId;");

            //await context.Database.ExecuteSqlCommandAsync(sb.ToString(), cartIdparam);
            context.Cart.Remove(new CartEntity { CartId = cartId });
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(long cartProductId)
        {
            context.Cart.Remove(new CartEntity { Id = cartProductId });
            await context.SaveChangesAsync();
        }

        public async Task<CartEntity> SaveAsync(CartEntity item)
        {
            if (item.Id > 0)
                context.Cart.Update(item);

            else
                await context.Cart.AddAsync(item);

            await context.SaveChangesAsync();

            // get the record to ensure price reflects true values
            return await context.Cart.FirstOrDefaultAsync(f => f.Id == item.Id);
        }


    }
}
