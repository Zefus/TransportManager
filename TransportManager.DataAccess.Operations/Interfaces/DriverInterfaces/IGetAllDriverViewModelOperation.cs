using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;

namespace TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces
{
    public interface IGetAllDriverViewModelOperation
    {
        Task<IEnumerable<DriverViewModel>> ExecuteAsync();
    }
}
