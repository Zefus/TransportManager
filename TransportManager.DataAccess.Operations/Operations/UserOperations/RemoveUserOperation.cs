using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Threading;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess.Operations.Interfaces.UserInterfaces;
using TransportManager.DataAccess.Models;

namespace TransportManager.DataAccess.Operations.Operations.UserOperations
{
    [Export(typeof(IRemoveUserOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RemoveUserOperation : IRemoveUserOperation
    {
        [Import]
        private IRepositoryProvider _repositoryProvider { get; set; }

        public async Task<bool> ExecuteAsync(params object[] keyValues)
        {
            var userRepository = _repositoryProvider.GetRepository<User>();

            var user = await userRepository.FindAsync(CancellationToken.None, keyValues);

            await userRepository.RemoveAsync(user);

            await _repositoryProvider.SaveChangesAsync();

            return true;
        }
    }
}
