using Microsoft.EntityFrameworkCore;

namespace Checkout.EntityFramework
{
    using Models;

    public class CheckoutContext : DbContext
    {

        public CheckoutContext()
        { }

        public CheckoutContext(DbContextOptions<CheckoutContext> options)
            : base(options)
        {
        }


        // entity config
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<ProductEntity> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
