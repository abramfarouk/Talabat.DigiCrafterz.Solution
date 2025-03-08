using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class Specifications<T> : ISpecifications<T> where T : BaseEntity
    {


        public Expression<Func<T, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IsPaginationEnabled { get; set; }


        //if case criteria null GetAllProduct
        public Specifications()
        {
            //Includes = new List<Expression<Func<T, object>>>();

        }

        //GetById
        public Specifications(Expression<Func<T, bool>> CriteriaExpresstion)
        {
            Criteria = CriteriaExpresstion; // p=> p.id == 10
                                            //Includes = new List<Expression<Func<T, object>>>();

        }

        public void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }


        public void ApplyPagination(int Skip, int Take)
        {
            IsPaginationEnabled = true;
            this.Skip = Skip;
            this.Take = Take;
        }


    }
}
