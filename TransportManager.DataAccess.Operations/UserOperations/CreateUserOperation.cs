using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.UserOperationsInterfaces;

namespace TransportManager.DataAccess.Operations.UserOperations
{
    [Export(typeof(ICreateUserOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CreateUserOperation : ICreateUserOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<bool> ExecuteAsync(User user)
        {
            var userRepository = _repositoryProvider.GetRepository<User>();
            await userRepository.AddAsync(user, CancellationToken.None);
            await _repositoryProvider.SaveChangesAsync();

            return true;
        }
    }
}
