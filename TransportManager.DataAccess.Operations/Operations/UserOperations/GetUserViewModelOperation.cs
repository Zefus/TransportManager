using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.Interfaces.UserInterfaces;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.Operations.UserOperations
{
    [Export(typeof(IGetUserViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetUserViewModelOperation : IGetUserViewModelOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<IEnumerable<UserViewModel>> ExecuteAsync(Expression<Func<User, bool>> predicate,
            params Expression<Func<User, object>>[] includes)
        {
            var userRepository = _repositoryProvider.GetRepository<User>();

            List<User> users = (List<User>)await userRepository
                .GetAsync(predicate, CancellationToken.None, includes);

            List<UserViewModel> userViewModels = new List<UserViewModel>();

            users.ForEach(u => userViewModels.Add(
                new UserViewModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    MiddleName = u.MiddleName,
                    Email = u.Email,
                    Phone = u.Phone,
                    LastVisit = u.LastVisit
                }
                )
            );

            return userViewModels;
        }
    }
}
