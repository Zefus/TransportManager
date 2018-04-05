using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Operations.ViewModels.DriverViewModels;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DriverController : ApiController
    {
        [Import]
        private IFindDriverViewModelOperation FindDriverViewModelOperation { get; set; }
        [Import]
        private IGetAllDriverViewModelOperation GetAllDriverViewModelOperation { get; set; }
        [Import]
        private ICreateDriverOperation CreateDriverOperation { get; set; }
        [Import]
        private IRemoveDriverOperation RemoveDriverOperation { get; set; }

        [HttpGet]
        public async Task<DriverViewModel> Find(params object[] keyValues)
        {
            var driver = await FindDriverViewModelOperation.ExecuteAsync(keyValues);
            return driver;
        }

        [HttpGet]
        public async Task<IEnumerable<DriverViewModel>> GetAll()
        {
            var drivers = await GetAllDriverViewModelOperation.ExecuteAsync();

            return drivers;
        }

        [HttpPost]
        public async Task<bool> Create([FromBody]Driver driver)
        {
            if (driver == null)
                return false;

            return await CreateDriverOperation.ExecuteAsync(driver);
        }

        [HttpPost]
        public async Task<bool> Delete([FromBody]object id)
        {
            if (id == null)
                return false;

            return await RemoveDriverOperation.ExecuteAsync(id);
        }
    }
}
