namespace Talabat.Core.Entities
{
    //expression about ProductId as Selected in basketItem
    public class BasketItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
    }
}