using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Operations.ViewModels;

namespace TransportManager.DataAccess.Operations
{
    public interface IGetAllUserViewModelOperation
    {
        Task<IEnumerable<UserViewModel>> ExecuteAsync();
    }
}
