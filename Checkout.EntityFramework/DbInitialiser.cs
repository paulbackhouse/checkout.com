using System.Linq;

namespace Checkout.EntityFramework
{

    using Models;


    /// <summary>
    /// Seeds the data for the context
    /// </summary>
    public static class DbInitialiser
    {

        private static CheckoutContext context;

        public static void Initialize(CheckoutContext ctx)
        {
            context = ctx;

            context.Database.EnsureCreated();

            Countries();
            Products();

        }

        // add countries
        private static void Countries()
        {
            if (!context.Country.Any())
            {
                context.Add(new CountryEntity { Id = 1, Name = "Germany", IsoCode = "de-DE", Tax = 22.5M, IsDefault = true, IsActive = true });
                context.Add(new CountryEntity { Id = 2, Name = "United Kingdom", IsoCode = "en-GB", Tax = 17.5M, IsActive = true });

                context.SaveChanges();
            }
        }

        // add products
        private static void Products()
        {
            if (!context.Product.Any())
            {
                context.Add(new ProductEntity { Id = 1, Name = "Pencil", Code = "100101", NetPrice = 1.99M, ShortDescription = "A narrow, generally cylindrical implement for writing, drawing, or marking.", CountryId = 1, IsActive = true });
                context.Add(new ProductEntity { Id = 2, Name = "Pen", Code = "100102", NetPrice = 2.99M, ShortDescription = "A common writing instrument used to apply ink to a surface, usually paper, for writing or drawing.", CountryId = 1, IsActive = true });
                context.Add(new ProductEntity { Id = 3, Name = "Paper", Code = "100103", NetPrice = 3.99M, ShortDescription = "A thin material produced by pressing together moist fibres of cellulose pulp derived from wood, rags or grasses, and drying them into flexible sheets.", CountryId = 1, IsActive = true });

                context.Add(new ProductEntity { Id = 4, Name = "Pencil", Code = "100104", NetPrice = 2.99M, ShortDescription = "A narrow, generally cylindrical implement for writing, drawing, or marking.", CountryId = 2, IsActive = true });
                context.Add(new ProductEntity { Id = 5, Name = "Pen", Code = "100105", NetPrice = 3.99M, ShortDescription = "A common writing instrument used to apply ink to a surface, usually paper, for writing or drawing.", CountryId = 2, IsActive = true });
                context.Add(new ProductEntity { Id = 6, Name = "Paper", Code = "100106", NetPrice = 4.99M, ShortDescription = "A thin material produced by pressing together moist fibres of cellulose pulp derived from wood, rags or grasses, and drying them into flexible sheets.", CountryId = 2, IsActive = true });

                context.SaveChanges();
            }
        }
    }
}
