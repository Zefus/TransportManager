using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces
{
    public interface IRemoveDriverOperation
    {
        Task<bool> ExecuteAsync(params object[] keyValues);
    }
}
