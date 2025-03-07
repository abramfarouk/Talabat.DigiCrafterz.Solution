using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.DTOS.ProductDtos;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications.Product_Specs;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ProductResponseDto>> GetAllAsync()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var products = await _productRepo.GetAllWithSpecAsync(spec);

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponseDto>>(products));
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(Guid id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);

            var product = await _productRepo.GetByIdWithSpecAsync(spec);

            if (product == null)
            {
                return NotFound(new { message = $"Product Not Found With Id => [{id}] Try Again !" });
            }

            return Ok(_mapper.Map<Product, ProductResponseDto>(product));

        }
    }
}
