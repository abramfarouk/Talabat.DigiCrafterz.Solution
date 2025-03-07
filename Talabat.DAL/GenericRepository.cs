using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Ctor 
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Functions 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);

        }
        public async Task<bool> AddAsync(T entity)
        {

            //_context.TablesName.Add(entity)
            await _context.Set<T>().AddAsync(entity);
            var effectedRow = await _context.SaveChangesAsync();
            if (effectedRow >= 1) return true;
            return false;
        }
        public async Task<bool> UpdateAnsyc(T etity)
        {
            _context.Set<T>().Update(etity);
            var effectedRow = await _context.SaveChangesAsync();
            if (effectedRow >= 1) return true;
            return false;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            var effectedRow = await _context.SaveChangesAsync();
            if (effectedRow >= 1) return true;
            return false;
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _context.Set<T>().AsTracking().AsQueryable();
        }
        public IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }
        public async Task RollBackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();

        }


        private IQueryable<T> ApplySpecifications(ISpecifications<T> specifications)
            => SPecificationsEvaluator<T>.GetQuery(_context.Set<T>(), specifications);



        #endregion

    }

}
