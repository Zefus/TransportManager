using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Infrastructure.Interfaces;

namespace TransportManager.DataAccess.Infrastructure
{
    public interface IRepositoryProvider<TEntity> : IDisposable
        where TEntity : class
    {
        IEntityRepository<TEntity> GetRepository();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
