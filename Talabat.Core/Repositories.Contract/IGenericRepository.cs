using Microsoft.EntityFrameworkCore.Storage;
using Talabat.Core.Entities;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //-------CRUD-------------------
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAnsyc(T etity);
        Task<bool> DeleteAsync(T entity);

        //-------Tracking---------------

        IQueryable<T> GetTableAsTracking();
        IQueryable<T> GetTableNoTracking();

        //----------Transcation----------
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();






    }
}
