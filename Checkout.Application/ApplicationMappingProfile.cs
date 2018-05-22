using AutoMapper;

namespace Checkout.Application
{
    using Inventory;
    using Location;
    using Models;

    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            Create<ProductEntity, ProductDto>();
            Create<CountryEntity, CountryDto>();
        }


        /// <summary>
        /// Creates a two way automap configuration
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        void Create<TSource, TDestination>()
            where TSource : class
            where TDestination : class
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }

    }
}
