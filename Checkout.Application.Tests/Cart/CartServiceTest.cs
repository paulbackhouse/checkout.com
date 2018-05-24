using System;
using Xunit;
using Moq;

namespace Checkout.Application.Tests.Cart
{
    using Checkout.Cart;
    using Checkout.Exceptions;
    using Checkout.Inventory;
    using Checkout.Location;
    using Checkout.Models;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartServiceTest : BaseTest, IClassFixture<ApplicationMappingProfile>
    {
        private readonly ICartService service;
        private readonly Mock<ICartRepository> cartRepo;
        private readonly Mock<ICountryService> countrySer;
        private readonly Mock<IProductRepository> productRepo;
        private readonly Mock<ILogger<CartService>> logger;


        public CartServiceTest()
        {
            ConfigureMapper();

            cartRepo = new Mock<ICartRepository>();
            logger = new Mock<ILogger<CartService>>();
            countrySer = new Mock<ICountryService>();
            productRepo = new Mock<IProductRepository>();

            service = new CartService(logger.Object, cartRepo.Object, countrySer.Object, productRepo.Object);
        }

        [Fact]
        public async Task ItGetsCartById()
        {
            cartRepo.Setup(s => s.GetAsync(It.IsAny<Guid>())).ReturnsAsync(new List<CartEntity>
            {
                new CartEntity { CartId = Guid.NewGuid() },
                new CartEntity { CartId = Guid.NewGuid() }
            });

            var result = await service.GetByIdAsync(Guid.NewGuid());

            Assert.IsType<CartDto>(result);
            Assert.True(result.Items.Count() == 2);
        }

        [Fact]
        public async Task ItGetsCartByIdAndThrowsException()
        {
            bool errorCaught = false;
            var cartId = Guid.NewGuid();

            cartRepo.Setup(s => s.GetAsync(It.IsAny<Guid>())).Throws<Exception>();

            try
            {
                var result = await service.GetByIdAsync(cartId);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                // assert.throws doesn't seem to work with async methods, retro test logic applied
                errorCaught = true;
            }

            VerifyLog();
            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItRemovesACart()
        {
            await service.RemoveAsync(Guid.NewGuid());
            cartRepo.Verify(v => v.RemoveAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task ItRemovesACartAndThrowsException()
        {
            bool errorCaught = false;
            cartRepo.Setup(s => s.RemoveAsync(It.IsAny<Guid>())).Throws<Exception>();

            try
            {
                await service.RemoveAsync(Guid.NewGuid());
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            VerifyLog();
            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItRemovesACartItem()
        {
            await service.RemoveAsync(Guid.NewGuid(), It.IsAny<int>());
            cartRepo.Verify(v => v.RemoveAsync(It.IsAny<Guid>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task ItRemovesACartItemAndThrowsException()
        {
            bool errorCaught = false;
            cartRepo.Setup(s => s.RemoveAsync(It.IsAny<Guid>(), It.IsAny<int>())).Throws<Exception>();

            try
            {
                await service.RemoveAsync(Guid.NewGuid(), 1);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            VerifyLog();
            Assert.True(errorCaught);
        }


        [Fact]
        public async Task ItSavesCartItemToCart()
        {

            productRepo.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProductEntity
            {
                CountryId = 1
            });

            cartRepo.Setup(s => s.SaveAsync(It.IsAny<CartEntity>())).ReturnsAsync(Mock.Of<CartEntity>());

            var result = await service.SaveAsync(new CartItemDto { ProductId = 1, CountryId = 1 });

            cartRepo.Verify(v => v.SaveAsync(It.IsAny<CartEntity>()), Times.Once);
            productRepo.Verify(v => v.GetByIdAsync(It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public async Task ItDoesNotAddInvalidProductAndThrowException()
        {
            bool errorCaught = false;
            productRepo.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(Mock.Of<ProductEntity>());

            try
            {
                var result = await service.SaveAsync(new CartItemDto { ProductId = 1, CountryId = 2 });
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
        public async Task ItSaveCartItemAndThrowsException()
        {
            bool errorCaught = false;
            productRepo.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProductEntity
            {
                CountryId = 1
            });

            cartRepo.Setup(s => s.SaveAsync(It.IsAny<CartEntity>())).Throws<Exception>();

            try
            {
                var result = await service.SaveAsync(new CartItemDto { ProductId = 1, CountryId = 1 });
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (CartException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                errorCaught = true;
            }

            VerifyLog();
            Assert.True(errorCaught);
        }



        void VerifyLog(LogLevel level = LogLevel.Error, int callAmount = 1)
        {
            logger.Verify(v =>
            v.Log(
                level,
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()),
                Times.Exactly(callAmount));
        }

    }
}
