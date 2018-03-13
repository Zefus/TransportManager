using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Infrastructure;

namespace TransportManager.DataAccess.Operations
{
    [Export(typeof(IFindUserViewModelOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FindUserViewModelOperation : IFindUserViewModelOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<UserViewModel> ExecuteAsync(params object[] keyValues)
        {
            var user = await _repositoryProvider
                .GetRepository<User>()
                .FindAsync(CancellationToken.None, keyValues);

            if (user == null)
                throw new Exception("There is no user in the database");

            UserViewModel userViewModel = new UserViewModel();

            userViewModel.FirstName = user.FirstName;
            userViewModel.MiddleName = user.MiddleName;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.Phone = user.Phone;

            return userViewModel;
        }
    }
}
