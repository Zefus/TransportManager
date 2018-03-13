using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess;
using TransportManager.DataAccess.Infrastructure.Interfaces;
using TransportManager.DataAccess.Infrastructure.Helpers;

namespace TransportManager.DataAccess.Infrastructure.Repositories
{
    [Export(typeof(IEntityRepository<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class
    {
        private DbContext _dbContext;

        public DbSet<TEntity> Set { get; }

        public EntityRepository(DbContext context)
        {
            _dbContext = context;
            Set = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> FindAsync(
            CancellationToken cancellationToken,
            params object[] keyValues)
        {
            var entity = await Set.FindAsync(cancellationToken, keyValues).ConfigureAwait(false);
            return entity ?? throw new Exception("Entity is not found");
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().Where(predicate);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Set.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Set.Add(entity);
            return InternalHelper.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Set.AddRange(entities);
            return InternalHelper.CompletedTask;
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Set.Remove(entity);
            return InternalHelper.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Set.RemoveRange(entities);
            return InternalHelper.CompletedTask;
        }
    }
}
