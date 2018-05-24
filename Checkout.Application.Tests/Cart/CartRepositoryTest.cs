using System;
using Xunit;

namespace Checkout.Application.Tests.Cart
{
    using Checkout.Cart;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartRepositoryTest : BaseTest
    {
        private readonly Guid cartId = Guid.NewGuid();
        private readonly ICartRepository repo;

        public CartRepositoryTest()
        {
            MockContext();
            PopulateData();
            repo = new CartRepository(context);
        }

        [Fact]
        public async Task ItGetsCart()
        {
            var result = await repo.GetAsync(cartId);
            Assert.Equal(1, result.Count);

            var match = result.First();
            Assert.Equal(match.ProductId, (int)1);
            Assert.Equal(match.CountryId, (int)1);
            Assert.Equal(match.Qty, (int)1);
        }

        [Fact]
        public async Task ItGetsCartItem()
        {
            var result = await repo.GetAsync(cartId, 1);
            Assert.Equal(result.ProductId, (int)1);
            Assert.Equal(result.CountryId, (int)1);
            Assert.Equal(result.Qty, (int)1);
        }

        void PopulateData()
        {
            context.Cart.Add(new Models.CartEntity
            {
                CartId = cartId,
                ProductId = 1,
                CountryId = 1,
                Qty = 1
            });
            context.Cart.Add(new Models.CartEntity
            {
                CartId = Guid.NewGuid(),
                ProductId = 4,
                CountryId = 2,
                Qty = 3
            });

            context.SaveChanges();
        }

    }
}
