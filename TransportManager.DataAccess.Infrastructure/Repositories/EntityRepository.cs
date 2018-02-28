using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TransportManager.DataAccess;

namespace TransportManager.DataAccess.Infrastructure.Repositories
{
    public class EntityRepository<TEntity>
        where TEntity : class
    {
        private DbContext _dbContext { get; }

        public DbSet<TEntity> Set { get; }

        public EntityRepository()
        {
            _dbContext = new TransportManagerContext();
            Set = _dbContext.Set<TEntity>();
        }

        
    }
}
