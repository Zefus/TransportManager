using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Infrastructure.Interfaces;
using TransportManager.DataAccess.Infrastructure.Repositories;

namespace TransportManager.DataAccess.Infrastructure
{
    [Export(typeof(IRepositoryProvider<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RepositoryProvider<TEntity> : IRepositoryProvider<TEntity>
        where TEntity : class
    {
        private DbContext _dbContext;
        private bool disposed = false;

        public RepositoryProvider()
        {
            _dbContext = new TransportManagerContext();
        }

        public IEntityRepository<TEntity> GetRepository()
        {
            if (!disposed)
            {
                var repository = new EntityRepository<TEntity>(_dbContext);
                return repository;
            }

            throw new ObjectDisposedException(GetType().Name);
        }

        public virtual int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }
                disposed = true;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
