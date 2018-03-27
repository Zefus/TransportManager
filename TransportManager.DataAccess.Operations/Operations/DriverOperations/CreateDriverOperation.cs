using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.DataAccess.Operations.Operations.DriverOperations
{
    [Export(typeof(ICreateDriverOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CreateDriverOperation : ICreateDriverOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<bool> ExecuteAsync(Driver driver)
        {
            var driverRepository = _repositoryProvider.GetRepository<Driver>();
            await driverRepository.AddAsync(driver, CancellationToken.None);
            await _repositoryProvider.SaveChangesAsync();

            return true;
        }
    }
}
