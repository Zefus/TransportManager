using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces
{
    public interface ICreateDriverOperation
    {
        Task<bool> ExecuteAsync(Driver driver);
    }
}
