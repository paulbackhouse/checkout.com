using Checkout.Caching;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Checkout.Application.Tests.Caching
{
    public class MemoryCacheServiceTest
    {
        private readonly ICacheService service;
        private readonly IMemoryCache memCache;
        private readonly ILogger<MemoryCacheService> logger;

        public MemoryCacheServiceTest()
        {
            memCache = new MemoryCache(new MemoryCacheOptions());
            logger = Mock.Of<ILogger<MemoryCacheService>>();

            service = new MemoryCacheService(logger, memCache);
        }

        [Fact]
        public void ItStoresValueForMaxDateTime()
        {
            var result = service.Get<string>("key", new Func<string>(() =>
            {
                return "value";
            }), null);

            Assert.Equal("value", result);
            Assert.Equal("value", memCache.Get("key"));
        }

        [Fact]
        public void ItStoresValueForCustomDateTime()
        {
            var result = service.Get<object>("key",
                DateTime.Now.AddSeconds(1),
                new Func<string>(() =>
                {
                    return "value";
                }), null);

            Thread.Sleep(2000);

            Assert.Equal("value", result);
            Assert.True(memCache.Get("key") == null);
        }

        [Fact]
        public void ItDoeNotStoreNull()
        {
            Assert.Throws<InvalidOperationException>(
                new Action(() => {
                    service.Get<object>("key", new Func<object>(() =>
                    {
                        return null;
                    }), null);
                }));


        }

        [Fact]
        public void ItSetsAValue()
        {
            service.Set("key", "value", DateTime.Now.AddSeconds(2));
            Assert.Equal("value", memCache.Get("key"));
        }

        [Fact]
        public void ItRemovesAValue()
        {
            service.Set("key", "value", DateTime.Now.AddMinutes(1));
            Assert.Equal("value", memCache.Get("key"));
            service.Remove("key");
            Assert.Null(memCache.Get("key"));
        }        

        [Fact]
        public void ItCleansCacheKey()
        {
            service.Set("a key", "value", DateTime.Now.AddSeconds(5));
            Assert.NotNull(memCache.Get("a-key"));
        }

    }
}
