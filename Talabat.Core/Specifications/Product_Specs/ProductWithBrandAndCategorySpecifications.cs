using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithBrandAndCategorySpecifications : Specifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications() : base()
        {
            AddIncludes();

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
