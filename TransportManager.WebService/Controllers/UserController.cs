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
using TransportManager.DataAccess.Operations;
using TransportManager.DataAccess.Operations.ViewModels;
using TransportManager.DataAccess.Infrastructure;

namespace TransportManager.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserController : ApiController
    {
        [Import]
        private IGetAllUserViewModelOperation GetGetAllUserViewModelOperation { get; set; }
        [Import]
        private IFindUserViewModelOperation FindUserViewModelOperation { get; set; }
        [Import]
        private ICreateUserOperation CreateUserOperation { get; set; }

        [HttpGet]
        public async Task<UserViewModel> Find(params object[] keyValues)
        {
            var user = await FindUserViewModelOperation.ExecuteAsync(keyValues);
            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await GetGetAllUserViewModelOperation.ExecuteAsync();
            return users;
        }

        //public async Task<IEnumerable<User>> Get()
        //{
            
        //}

        [HttpPost]
        public async Task<bool> Create([FromBody]User user)
        {
            if (user == null)
                return false;

            return await CreateUserOperation.ExecuteAsync(user);
        }
    }
}
