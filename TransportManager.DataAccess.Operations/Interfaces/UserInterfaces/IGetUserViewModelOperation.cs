using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.Interfaces.UserInterfaces
{
    public interface IGetUserViewModelOperation
    {
        Task<IEnumerable<UserViewModel>> ExecuteAsync(Expression<Func<User, bool>> predicate,
            params Expression<Func<User, object>>[] includes);
    }
}
