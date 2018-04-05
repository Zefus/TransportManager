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
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;

namespace TransportManager.DataAccess.Operations.Operations.DriverOperations
{
    [Export(typeof(IFindDriverViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FindDriverViewModelOperation : IFindDriverViewModelOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<DriverViewModel> ExecuteAsync(params object[] keyValues)
        {
            var driverRepository = _repositoryProvider.GetRepository<Driver>();
            var driver = await driverRepository.FindAsync(CancellationToken.None, keyValues);

            DriverViewModel driverViewModel = new DriverViewModel
            {
                Firstname = driver.FirstName,
                LastName = driver.LastName,
                MiddleName = driver.MiddleName
            };

            return driverViewModel;
        }
    }
}
