using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Infrastructure.Interfaces;

namespace TransportManager.DataAccess.Infrastructure
{
    public interface IRepositoryProvider : IDisposable
    {
        IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
