using System.Linq.Expressions;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }  //1-where  //p=>p.id==1


        public List<Expression<Func<T, object>>> Includes { get; set; }


    }
}
