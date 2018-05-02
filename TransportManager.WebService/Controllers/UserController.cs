using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.WebService.Converters;
using TransportManager.DataAccess.Operations.Interfaces.UserInterfaces;
using TransportManager.DataAccess.Operations.ViewModels;

namespace TransportManager.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserController : ApiController
    {
        [Import]
        private IGetAllUserViewModelOperation GetAllUserViewModelOperation { get; set; }
        [Import]
        private IFindUserViewModelOperation FindUserViewModelOperation { get; set; }
        [Import]
        private ICreateUserOperation CreateUserOperation { get; set; }
        [Import]
        private IRemoveUserOperation RemoveUserOperation { get; set; }
        [Import]
        private IGetUserViewModelOperation GetUserViewModelOperation { get; set; }

        [HttpGet]
        public async Task<UserViewModel> Find(params object[] keyValues)
        {
            var user = await FindUserViewModelOperation.ExecuteAsync(keyValues);
            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await GetAllUserViewModelOperation.ExecuteAsync();
            return users;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get(string keyValues)
        {
            var lymbdaExpression = LambdaConverter.Convert<User>(keyValues);
            var users = await GetUserViewModelOperation.ExecuteAsync(lymbdaExpression);
            return users;
        }

        [HttpPost]
        public async Task<bool> Create([FromBody]User user)
        {
            if (user == null)
                return false;

            return await CreateUserOperation.ExecuteAsync(user);
        }

        [HttpPost]
        public async Task<bool> Delete([FromBody]object keyValues)
        {    if (keyValues == null)
                return false;

            return await RemoveUserOperation.ExecuteAsync(keyValues);
        }
    }
}
