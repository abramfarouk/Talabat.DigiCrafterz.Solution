namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;
        private int MinPageSize = 5;
        public int PageSize
        {

            get { return MinPageSize; }
            set { MinPageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;

        public string? Search { get; set; }
        public string? Sort { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
    }
}
