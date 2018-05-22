using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Checkout.Inventory
{
    using EntityFramework;
    using Interfaces;
    using Location;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository for CRUD product related queries
    /// </summary>
    public class ProductRepository : IProductRepository, ITransientService
    {
        private readonly CheckoutContext context;

        // TODO: replace with valid logic
        public ProductRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<ProductEntity>> GetAsync(short countryId, bool? isActive)
        {
            return await context
                .Product
                .Include(products => products.Country)
                .Where(w => w.CountryId == countryId && (isActive == null || w.IsActive == (bool)isActive))
                .ToListAsync();
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            return await context.Product.FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
