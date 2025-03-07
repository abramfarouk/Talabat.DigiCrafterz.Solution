namespace Talabat.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
