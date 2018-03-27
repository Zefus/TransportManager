using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.ComponentModel.Composition;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Operations.Interfaces.DriverInterfaces;

namespace TransportManager.WebService.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DriverController : ApiController
    {
        [Import]
        private ICreateDriverOperation CreateDriverOperation { get; set; }

        [HttpPost]
        public async Task<bool> Create([FromBody]Driver driver)
        {
            if (driver == null)
                return false;

            return await CreateDriverOperation.ExecuteAsync(driver);
        }
    }
}
