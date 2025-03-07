namespace Talabat.Core.DTOS.ProductDtos
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public Guid BrandId { get; set; }
        public string Brand { get; set; }

        public Guid CategoryId { get; set; }
        public string Category { get; set; }
    }
}
