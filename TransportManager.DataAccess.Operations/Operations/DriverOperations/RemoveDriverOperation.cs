using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.DataAccess.Operations.Operations.DriverOperations
{
    [Export(typeof(IRemoveDriverOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RemoveDriverOperation : IRemoveDriverOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<bool> ExecuteAsync(params object[] keyValues)
        {
            var driverRepository = _repositoryProvider.GetRepository<Driver>();

            var driver = await driverRepository.FindAsync(CancellationToken.None, keyValues);

            await driverRepository.RemoveAsync(driver);

            await _repositoryProvider.SaveChangesAsync();

            return true;
        }
    }
}
