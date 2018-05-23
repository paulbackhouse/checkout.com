using AutoMapper;

namespace Checkout.Application
{
    using Cart;
    using Extensions;
    using Inventory;
    using Location;
    using Models;

    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            Create<CountryEntity, CountryDto>();
            Create<ProductEntity, ProductDto>();
            CreateCartMapping();
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

        // Cart special projection mapping
        void CreateCartMapping()
        {
            Create<CartEntity, CartDto>();
            CreateMap<CartProductDto, CartEntity>();

            // custom CartProductDto map (a Dto describing cart "product" logic)
            CreateMap<CartEntity, CartProductDto>()
                .ForMember(dest => dest.CountryIsoCode, opt => opt.MapFrom(src => src.Country.IsoCode))
                .ForMember(dest => dest.NetPrice, opt => opt.MapFrom(src => src.Product.NetPrice))
                .ForMember(dest => dest.TaxAmount, opt => opt.MapFrom(src => src.Product.NetPrice.AsTaxAmount(src.Country.Tax)));
        }
    }
}
