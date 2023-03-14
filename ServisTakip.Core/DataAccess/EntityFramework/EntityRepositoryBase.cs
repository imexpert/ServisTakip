using ServisTakip.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ServisTakip.Core.DataAccess.EntityFramework
{
    public class EntityRepositoryBase<TEntity, TContext>
        : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public EntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.ChangeTracker.Clear();

            return Context.Add(entity).Entity;
        }

        public void AddRange(List<TEntity> entityList)
        {
            Context.ChangeTracker.Clear();
            Context.AddRange(entityList);
        }

        public void Delete(TEntity entity)
        {
            Context.ChangeTracker.Clear();

            Context.Remove(entity);
        }

        public void DeleteRange(List<TEntity> entityList)
        {
            Context.ChangeTracker.Clear();

            Context.RemoveRange(entityList);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().FirstOrDefault(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? Context.Set<TEntity>().AsNoTracking()
                : Context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? await Context.Set<TEntity>().ToListAsync()
                : await Context.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            Context.ChangeTracker.Clear();

            Context.Update(entity);
            return entity;
        }
    }
}
