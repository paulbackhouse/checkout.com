using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Inventory
{
    using EntityFramework;
    using Extensions;
    using Interfaces;
    using Models;

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

        public async Task<IList<ProductEntity>> GetAsync(PagerDto pager, short countryId, bool? isActive)
        {
            return await context
                .Product
                .Include(products => products.Country)
                .Where(w => w.CountryId == countryId && (isActive == null || w.IsActive == (bool)isActive))
                .Paged(pager)
                .ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await context
                        .Product
                        .Include(products => products.Country)
                        .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
