using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.UserOperationsInterfaces
{
    public interface ICreateUserOperation
    {
        Task<bool> ExecuteAsync(User user);
    }
}
