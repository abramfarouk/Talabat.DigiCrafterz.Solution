using System.Net;
using Talabat.Core.Helper;

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

        [HttpGet]
        public IActionResult Index(int Id)
        {

            return Ok();
        }



        [HttpGet("GetAll")]
        public async Task<ActionResult<ProductResponseDto>> GetAllAsync([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams);
            var products = await _productRepo.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponseDto>>(products);
            var specCount = new ProductwithFiterationSpecCount(specParams);
            var count = await _productRepo.CountAsync(specCount);

            return Ok(new Pagination<ProductResponseDto>(specParams.PageIndex, specParams.PageSize, count, data));
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(Guid id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);

            var product = await _productRepo.GetByIdWithSpecAsync(spec);

            if (product == null)
            {
                return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
            }

            return Ok(_mapper.Map<Product, ProductResponseDto>(product));

        }
    }
}
