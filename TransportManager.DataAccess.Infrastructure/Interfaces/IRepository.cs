using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransportManager.DataAccess.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            params object[] keyValues);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken),
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task AddRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
