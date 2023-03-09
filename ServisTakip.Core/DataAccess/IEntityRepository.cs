using ServisTakip.Core.Entities;
using System.Linq.Expressions;

namespace ServisTakip.Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity
    {
        T Add(T entity);
        void AddRange(List<T> entityList);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
    }
}
