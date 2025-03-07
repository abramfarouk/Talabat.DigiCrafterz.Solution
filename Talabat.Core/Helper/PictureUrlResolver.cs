using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Core.DTOS.ProductDtos;
using Talabat.Core.Entities;

namespace Talabat.Core.Helper
{
    public class PictureUrlResolver : IValueResolver<Product, ProductResponseDto, string>
    {
        private readonly IConfiguration _configuration;
        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

