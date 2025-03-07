namespace Talabat.Core.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();    
        // i want to configration For EF can concept Relation


    }
}
