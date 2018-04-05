using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;

namespace TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces
{
    public interface IFindDriverViewModelOperation
    {
        Task<DriverViewModel> ExecuteAsync(params object[] keyValues);
    }
}
