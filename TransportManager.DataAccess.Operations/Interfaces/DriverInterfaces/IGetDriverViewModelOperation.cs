using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;

namespace TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces
{
    public interface IGetDriverViewModelOperation
    {
        Task<IEnumerable<DriverViewModel>> ExecuteAsync(Expression<Func<Driver, bool>> predicate,
            params Expression<Func<Driver, object>>[] includes);
    }
}
