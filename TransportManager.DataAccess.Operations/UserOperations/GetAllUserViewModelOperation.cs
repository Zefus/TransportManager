using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.UserOperationsInterfaces;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.UserOperations
{
    [Export(typeof(IGetAllUserViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetAllUserViewModelOperation : IGetAllUserViewModelOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<IEnumerable<UserViewModel>> ExecuteAsync()
        {
            List<User> users = (List<User>)await _repositoryProvider
                .GetRepository<User>()
                .GetAllAsync();

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
