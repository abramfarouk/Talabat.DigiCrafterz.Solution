using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Product>> GetAllAsync()
        {
            return Ok(await _productRepo.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"Product Not Found With Id => [{id}] Try Again !" });
            }

            return Ok(product);

        }
    }
}
