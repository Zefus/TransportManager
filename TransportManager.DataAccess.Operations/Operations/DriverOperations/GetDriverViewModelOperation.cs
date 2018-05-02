using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    [Export(typeof(IGetDriverViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetDriverViewModelOperation : IGetDriverViewModelOperation
    {
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<IEnumerable<DriverViewModel>> ExecuteAsync(Expression<Func<Driver, bool>> predicate,
            params Expression<Func<Driver, object>>[] includes)
        {
            var driverRepository = _repositoryProvider.GetRepository<Driver>();

            List<Driver> drivers = (List<Driver>)await driverRepository
                .GetAsync(predicate, CancellationToken.None, includes);

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
