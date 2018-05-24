using System.Collections.Generic;
using Xunit;

namespace Checkout.Application.Tests.Inventory
{
    using Checkout.Inventory;
    using Checkout.Models;
    using Moq;
    using System.Threading.Tasks;

    public class ProductServiceTest : BaseTest
    {
        private readonly IProductService service;
        private readonly Mock<IProductRepository> repo;

        public ProductServiceTest()
        {
            ConfigureMapper();
            repo = new Mock<IProductRepository>();
            service = new ProductService(repo.Object);
        }

        [Fact]
        public async Task ItGetsByCountryPaged()
        {
            repo.Setup(s => s.GetAsync(It.IsAny<PagerDto>(), 1, true)).ReturnsAsync(Mock.Of<List<ProductEntity>>());

            var results = await service.GetAsync(new PagerDto(), 1);

            Assert.IsType<List<ProductDto>>(results);
        }

        [Fact]
        public async Task ItGetsById()
        {
            repo.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(Mock.Of<ProductEntity>());

            var result = await service.GetByIdAsync(1);

            Assert.IsType<ProductDto>(result);
        }

    }
}
