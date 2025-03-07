using System.ComponentModel.DataAnnotations.Schema;

namespace Talabat.Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = null!;
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(Product.Category))]
        //[InverseProperty(nameof(Category.Products))]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
