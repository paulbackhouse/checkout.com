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

        [Fact]
        public async Task ItRemovesACart()
        {
            await repo.RemoveAsync(cartId);
            Assert.True(context.Cart.Count(f => f.CartId == cartId) == 0);
        }

        [Fact]
        public async Task ItRemovesACartItem()
        {
            await repo.RemoveAsync(cartId, 1);
            Assert.Null(context
                        .Cart
                        .FirstOrDefault(f => f.CartId == cartId && f.ProductId == 1));
        }

        [Fact]
        public async Task ItSavesNewItem()
        {
            await repo.SaveAsync(new Models.CartEntity
            {
                CartId = cartId,
                ProductId = 2,
                CountryId = 1,
                Qty = 2
            });

            Assert.True(context.Cart.Count(c => c.CartId == cartId) == 2);
            Assert.NotNull(context.Cart.FirstOrDefault(f => f.CartId == cartId && f.ProductId == 2));
        }

        [Fact]
        public async Task ItUpdatesAnItem()
        {
            await repo.SaveAsync(new Models.CartEntity
            {
                CartId = cartId,
                ProductId = 1,
                CountryId = 1,
                Qty = 5
            });

            var result = context.Cart.Where(f => f.CartId == cartId && f.ProductId == 1).ToList();

            Assert.True(result.Count == 1);
            Assert.True(result.First().Qty == 5);
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
