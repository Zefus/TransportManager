using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Operations.ViewModels;

namespace TransportManager.DataAccess.Operations.UserOperationsInterfaces
{
    public interface IFindUserViewModelOperation
    {
        Task<UserViewModel> ExecuteAsync(params object[] keyValues);
    }
}
