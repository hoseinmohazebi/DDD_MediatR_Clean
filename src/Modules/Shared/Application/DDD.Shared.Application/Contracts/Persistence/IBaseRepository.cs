using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Shared.Application.Contracts.Persistence
{
    public interface IBaseRepository<TEntity>
    {
        Task Delete(TEntity entity, bool saveChange = true);
        Task<TEntity?> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predict);
        IEnumerable<TEntity> GetAll();  
        Task<List<TEntity>> GetPagination(int skip, int size, System.Linq.Expressions.Expression<Func<TEntity, bool>>? predict = null);
        Task Insert(TEntity entity, bool saveChange = true);
        Task<int> SaveChangeAsync();
        Task<List<TEntity>> TolistAsync(CancellationToken cancellationToken = default, System.Linq.Expressions.Expression<Func<TEntity, bool>>? Criteria = null);
        Task Update(TEntity entity, bool saveChange = true);
    }
}
