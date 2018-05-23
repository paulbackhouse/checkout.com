using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Application
{
    using Caching;
    using Cart;
    using Location;
    using Inventory;

    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // register the services from this project
            // TODO: update to be more automated
            //       i.e. services that implement ITransientService are registered dynamically as Transient
            return services
                .AddTransient<ICacheService, MemoryCacheService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<ICartRepository, CartRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductRepository, ProductRepository>();
        }



    }
}
