using System.Collections.Generic;
using System.Linq;

namespace Checkout.Location
{
    using EntityFramework;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository for CRUD country related queries
    /// </summary>
    public class CountryRepository : ICountryRepository, ITransientService
    {
        private readonly CheckoutContext context;

        public CountryRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<CountryEntity>> GetAsync(bool? isActive)
        {
            return await context
                .Country
                .Where(w => isActive == null || w.IsActive == (bool)isActive)
                .ToListAsync();
        }

        public async Task<CountryEntity> GetAsync(short id)
        {
            return await context.Country.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
