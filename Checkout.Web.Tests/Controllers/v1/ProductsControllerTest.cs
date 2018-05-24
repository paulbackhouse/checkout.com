using System.Collections.Generic;
using Xunit;

namespace Checkout.Web.Tests.Controllers.v1
{
    using Checkout.Inventory;
    using Checkout.Web.Controllers.Api.v1;
    using Moq;
    using System.Threading.Tasks;

    public class ProductsControllerTest
    {

        private readonly Mock<IProductService> service;
        private readonly ProductsController ctrl;

        public ProductsControllerTest()
        {
            service = new Mock<IProductService>();
            ctrl = new ProductsController(service.Object);
        }

        [Fact]
        public async Task ItGetsPagedProducts()
        {
            service.Setup(s => s.GetAsync(It.IsAny<PagerDto>(),It.IsAny<short>())).ReturnsAsync(new List<ProductDto>());
            var result = await ctrl.Get((short)1);
            Assert.IsType<List<ProductDto>>(result);
        }

        [Fact]
        public async Task ItGetsCountryById()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProductDto());
            var result = await ctrl.Get(1);
            Assert.IsType<ProductDto>(result);
        }
    }
}
