using System.Net;
using Talabat.Core.DTOS.BasketDtos;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;
        public BasketsController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepo = basketRepository;
            _mapper = mapper;
        }


        [HttpGet("{BasketId}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string BasketId)
        {
            var basket = await _basketRepo.GetBasketAsync(BasketId);
            return Ok(basket ?? new CustomerBasket(BasketId));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdateBasket(CustomerBasketDto basket)
        {
            var mapBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var createdOrUpdateBasket = await _basketRepo.CreateOrUpdateBasketAsync(mapBasket);
            if (createdOrUpdateBasket == null) return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            return Ok(createdOrUpdateBasket);

        }

        [HttpDelete("{BasketId}")]
        public async Task<ActionResult<CustomerBasket>> RemoveBasketAsync(string BasketId)
        {
            var result = await _basketRepo.DeleteBasketAsync(BasketId);
            if (result is false) return BadRequest(new ApiErrorResponse(HttpStatusCode.NotFound));
            return Ok(new { message = "Delete Basket Successfully !" });
        }

    }
}
