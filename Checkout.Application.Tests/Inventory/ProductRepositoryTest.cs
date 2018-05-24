using Xunit;

namespace Checkout.Application.Tests.Inventory
{
    using Checkout.Inventory;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepositoryTest : BaseTest
    {

        private readonly IProductRepository repo;

        public ProductRepositoryTest()
        {
            MockContext();
            repo = new ProductRepository(context);
        }

        [Fact]
        public async Task ItGetsByCountryPaged()
        {
            var count = context.Product.Count();
            var country1Count = context.Product.Count(c => c.CountryId == 1);

            // get all - active
            var products = await repo.GetAsync(new PagerDto(), 1, true);

            Assert.True(products.Count == country1Count);

            // get paged selection - active
            products = await repo.GetAsync(new PagerDto(0, 1), 1, true);

            Assert.True(products.Count == 1);

            // gets inactive
            context.Product.Add(new Models.ProductEntity { Id = 8, Code = "test", CountryId = 1, IsActive = false });
            context.SaveChanges();

            var result = await repo.GetAsync(new PagerDto(), 1, false);

            Assert.True(result.Count == 1);
            Assert.False(result.First().IsActive);

        }

        [Fact]
        public async Task ItGetsById()
        {
            var result = await repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.True(result.Id == 1);
        }

    }
}
