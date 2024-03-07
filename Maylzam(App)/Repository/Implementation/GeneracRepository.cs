using Maylzam_App_.Repository.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Maylzam_App_.Model;

namespace Maylzam_App_.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //replace DbContex with ApplicationDbContext
        public DbDbContext _context;
        private IDbContextTransaction _transaction;
        internal DbSet<T> dbSet;
        private DbDbContext context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GenericRepository(DbDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
            this.dbSet = _context.Set<T>();


        }
        public virtual IQueryable<T> Entities => _context.Set<T>().AsNoTracking();

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            //  return await dbSet.ToListAsync();
            return await _context.Set<T>().ToListAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }


        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public EntityEntry<T> UpdateAndReturn(T entity)
        {
            var result = _context.Set<T>().Update(entity);

            return result;
        }
        public async Task<T> AddAndReturn(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            return result.Entity;
        }
        public T RemoveAndReturn(T entitiy)
        {
            var res = _context.Set<T>().Remove(entitiy);
            return res.Entity;

        }
        public async Task<T?> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }





        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();

            _context.Dispose();
        }






    }
}
