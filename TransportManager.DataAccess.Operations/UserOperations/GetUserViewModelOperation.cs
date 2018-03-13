using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations
{
    //public class GetUserViewModelOperation : IGetUserViewModelOperation
    //{
    //    [Import]
    //    private IRepositoryProvider _repositoryProvider { get; set; }

    //    public Task<IEnumerable<UserViewModel>> ExecuteAsync(Expression<Func<User, bool>> predicate,
    //        params Expression<Func<User, object>>[] includes)
    //    {

    //        var users = await _repositoryProvider
    //            .GetRepository<User>()
    //            .GetAsync();
    //    }
    //}
}
