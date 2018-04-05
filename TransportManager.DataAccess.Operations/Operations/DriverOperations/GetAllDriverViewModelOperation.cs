using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.DataAccess.Operations.Operations.DriverOperations
{
    [Export(typeof(IGetAllDriverViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetAllDriverViewModelOperation : IGetAllDriverViewModelOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<IEnumerable<DriverViewModel>> ExecuteAsync()
        {
            List<Driver> drivers = (List<Driver>)await _repositoryProvider
                .GetRepository<Driver>()
                .GetAllAsync();

            List<DriverViewModel> driverViewModels = new List<DriverViewModel>();

            drivers.ForEach(d => driverViewModels.Add(
                new DriverViewModel
                {
                    Firstname = d.FirstName,
                    LastName = d.LastName,
                    MiddleName = d.MiddleName
                }
                )
            );

            return driverViewModels;
        }
    }
}
