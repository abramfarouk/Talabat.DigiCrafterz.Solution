using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithBrandAndCategorySpecifications : Specifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams) : base(P =>
        //search - filter
        (string.IsNullOrEmpty(specParams.Search) || P.ProductName.ToLower().Contains(specParams.Search.ToLower())) &&
        (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId.Value) &&
        (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId.Value)

        )
        {
            AddIncludes();
            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        //OrderBy = p => p.Price;  
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(p => p.ProductName);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.ProductName);
            }


            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public ProductWithBrandAndCategorySpecifications(Guid id) : base(P => P.Id == id)
        {
            AddIncludes();
        }


        private void AddIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
