using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductwithFiterationSpecCount : Specifications<Product>
    {
        public ProductwithFiterationSpecCount(ProductSpecParams specParams) : base(

            P =>
      (string.IsNullOrEmpty(specParams.Search) || P.ProductName.ToLower().Contains(specParams.Search.ToLower())) &&
        (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId.Value) &&
        (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId.Value)

            )
        {

        }
    }
}
