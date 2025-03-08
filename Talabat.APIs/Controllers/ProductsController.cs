

using System.Net;

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
                return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
            }

            return Ok(_mapper.Map<Product, ProductResponseDto>(product));

        }
    }
}
