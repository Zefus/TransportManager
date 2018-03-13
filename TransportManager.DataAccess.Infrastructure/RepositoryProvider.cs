using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.Composition;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Infrastructure.Interfaces;
using TransportManager.DataAccess.Infrastructure.Repositories;

namespace TransportManager.DataAccess.Infrastructure
{
    [Export(typeof(IRepositoryProvider))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RepositoryProvider : IRepositoryProvider
    {
        private DbContext _dbContext;
        private bool disposed = false;

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected virtual IServiceLocator ServiceLocator { get; set; }

        public RepositoryProvider()
        {
            _dbContext = new TransportManagerContext();
        }

        public IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (!disposed)
            {
                var repository = new EntityRepository<TEntity>(_dbContext);

                return repository;
            }

            return ServiceLocator.GetInstance<IEntityRepository<TEntity>>();
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
