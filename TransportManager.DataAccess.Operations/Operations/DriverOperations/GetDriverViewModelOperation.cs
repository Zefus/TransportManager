using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.DataAccess.Operations.Operations.DriverOperations
{
    public class GetDriverViewModelOperation : IGetDriverViewModelOperation
    {
        public async IEnumerable<DriverViewModel> ExecuteAsync(Expression<Func<Driver, bool>>,
            params Expression<Func<Driver, object>>[] includes) { }
        {

        }
    }
}
