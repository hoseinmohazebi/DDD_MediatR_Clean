using DDD.Shared.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Shared.Infrastructure.Persistence
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext DbContext;
        protected DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        public BaseRepository(TContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Entities = DbContext.Set<TEntity>();
        }
        public virtual Task<List<TEntity>> TolistAsync(CancellationToken cancellationToken = default,
                                                       Expression<Func<TEntity, bool>>? Criteria = null)
        {
            var query = TableNoTracking;
            if (Criteria != null)
            {
                query = query.Where(Criteria);
            }
            return query.ToListAsync(cancellationToken);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return TableNoTracking.AsEnumerable();
        }
        public Task<TEntity?> Get(Expression<Func<TEntity, bool>> predict)
        {
            return TableNoTracking.SingleOrDefaultAsync(predict);
        }
        public virtual Task Insert(TEntity entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Add(entity);
            if (saveChange)
            {
                SaveChangeAsync();
            }
            return Task.CompletedTask;
        }
        public Task Update(TEntity entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Update(entity);
            if (saveChange)
            {
                SaveChangeAsync();
            }
            return Task.CompletedTask;

        }
        public Task Delete(TEntity entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Remove(entity);
            if (saveChange)
            {
                SaveChangeAsync();
            }
            return Task.CompletedTask;

        }
        public Task<int> SaveChangeAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
