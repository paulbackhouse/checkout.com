using System;
using System.Collections.Generic;

namespace Checkout.Inventory
{
    using Caching;
    using Extensions;
    using Interfaces;
    using System.Threading.Tasks;

    public class ProductService : IProductService, ITransientService
    {
        private readonly ICacheService cacheService;
        private readonly IProductRepository productRepository;

        public ProductService(ICacheService cacheService, IProductRepository productRepository)
        {
            this.cacheService = cacheService;
            this.productRepository = productRepository;
        }

        public IList<ProductDto> Get(short countryId)
        {
            return cacheService.Get<List<ProductDto>>(
                $"products-country-{countryId}",
                new Func<IList<ProductDto>>(() => {
                    // get products
                    var tsk = productRepository.GetAsync(countryId, true);
                    tsk.Wait();
                    return tsk.Result.MapList<ProductDto>();
                }));
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var item = await productRepository.GetAsync(id);
            return item.Map<ProductDto>();
        }
    }
}
