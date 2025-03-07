using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class Specifications<T> : ISpecifications<T> where T : BaseEntity
    {


        public Expression<Func<T, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

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


    }
}
