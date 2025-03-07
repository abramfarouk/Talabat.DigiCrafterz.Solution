using AutoMapper;
using Talabat.Core.DTOS.ProductDtos;
using Talabat.Core.Entities;

namespace Talabat.Core.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<PictureUrlResolver>());

        }

    }
}
