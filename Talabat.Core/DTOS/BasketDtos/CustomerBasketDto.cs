namespace Talabat.Core.DTOS.BasketDtos
{
    public class CustomerBasketDto
    {
        public string BasketId { get; set; }

        public List<BasketItemDto> basketItems { get; set; }

    }
}
