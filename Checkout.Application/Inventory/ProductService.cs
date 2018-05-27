namespace Checkout.Inventory
{
    using Extensions;
    using Interfaces;
    using System.Threading.Tasks;

    public class ProductService : IProductService, ITransientService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetAsync(PagerDto pager, short countryId)
        {
            var items = await productRepository.GetAsync(pager, countryId, true);
            return items.MapPaged<ProductDto>(pager);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var item = await productRepository.GetByIdAsync(id);
            return item.Map<ProductDto>();
        }
    }
}
