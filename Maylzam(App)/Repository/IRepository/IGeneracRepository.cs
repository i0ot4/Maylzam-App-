using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Maylzam_App_.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task<T> AddAndReturn(T entity);
        T RemoveAndReturn(T entitiy);
        void Remove(T entitiy);
        void Update(T entitiy);
        EntityEntry<T> UpdateAndReturn(T entity);
        Task<T?> GetById(int Id);



        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
