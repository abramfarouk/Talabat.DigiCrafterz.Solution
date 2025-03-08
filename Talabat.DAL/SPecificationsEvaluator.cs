using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal static class SPecificationsEvaluator<TEntity> where TEntity : BaseEntity //that like tables in DB
    {

        // any Query start with Dbset                             Aggragation
        // _context.set<Product>().where(p=>p.id==id).Include(p=>p.brand).Include(c=>c.Category) 
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)          // Dbset<> that always type Iquarble   , Object from class Specification
        {
            var query = inputQuery; // _context.set<Product>()

            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria); // _context.set<Product>().where(p=>p.Id ==1 )
            }
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);

            }


            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            if (spec.Includes.Count > 0)
            {
                query = spec.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            }





            return query;

        }
    }
}
