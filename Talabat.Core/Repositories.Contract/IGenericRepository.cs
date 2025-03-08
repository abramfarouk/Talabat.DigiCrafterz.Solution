using Microsoft.EntityFrameworkCore.Storage;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //-------CRUD-------------------
        Task<IEnumerable<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdWithSpecAsync(ISpecifications<T> spec);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAnsyc(T etity);
        Task<bool> DeleteAsync(T entity);


        Task<int> CountAsync(ISpecifications<T> spec);

        //-------Tracking---------------

        IQueryable<T> GetTableAsTracking();
        IQueryable<T> GetTableNoTracking();

        //----------Transcation----------
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();






    }
}
