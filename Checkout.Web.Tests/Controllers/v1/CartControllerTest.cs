using System;
using Xunit;

namespace Checkout.Web.Tests.Controllers.v1
{
    using Checkout.Cart;
    using Checkout.Exceptions;
    using Checkout.Web.Controllers.Api.v1;
    using Moq;
    using System.Threading.Tasks;

    public class CartControllerTest
    {

        private readonly Mock<ICartService> service;
        private readonly CartController ctrl;

        public CartControllerTest()
        {
            service = new Mock<ICartService>();
            ctrl = new CartController(service.Object);
        }

        [Fact]
        public async Task ItGetsACart()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new CartDto());
            var result = await ctrl.Get(Guid.NewGuid());
            Assert.IsType<CartDto>(result);
        }

        [Fact]
        public async Task ItGetsACartEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                var result = await ctrl.Get(Guid.Empty);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItGetsACartAndThrowsException()
        {
            bool errorCaught = false;
            service.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).Throws(new CartException("test"));

            try
            {
                var result = await ctrl.Get(Guid.Empty);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItSavesAnItem()
        {
            service.Setup(s => s.SaveAsync(It.IsAny<CartItemDto>())).ReturnsAsync(new CartProductDto());
            var result = await ctrl.Save(Mock.Of<CartItemDto>());
            Assert.IsType<CartProductDto>(result);
        }

        [Fact]
        public async Task ItRemovesACart()
        {
            // TODO: what does this actually test?
            await ctrl.Remove(Guid.NewGuid());
        }

        [Fact]
        public async Task ItRemovesACartEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                await ctrl.Remove(Guid.Empty);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }


        [Fact]
        public async Task ItRemovesACartProduct()
        {
            // TODO: what does this actually test?
            await ctrl.Remove(Guid.NewGuid(), 1);
        }

        [Fact]
        public async Task ItRemovesACartProductEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                await ctrl.Remove(Guid.Empty, 1);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }
    }
}
