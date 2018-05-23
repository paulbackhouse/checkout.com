using AutoMapper;

namespace Checkout.Application
{
    using Cart;
    using Inventory;
    using Location;
    using Models;

    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            Create<CartEntity, CartDto>();
            Create<CartProductEntity, CartProductDto>();
            Create<CountryEntity, CountryDto>();
            Create<CountryEntity, CountryDto>();
            Create<ProductEntity, ProductDto>();
        }


        /// <summary>
        /// Creates a two way automap configuration
        /// </summary>
        void Create<TSource, TDestination>()
            where TSource : class
            where TDestination : class
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }

    }
}
