using Microsoft.AspNetCore.Mvc;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using System.Collections.Generic;

namespace Saas.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceDbManager _serviceDbManager;
        public ServiceController(IServiceDbManager serviceDbManager)
        {
            _serviceDbManager = serviceDbManager;
        }

        [HttpGet]
        public List<ServiceReference> GetAllServices()
        {
            var serviceDetails = _serviceDbManager.GetAllServices();
            return serviceDetails;
        }
    }
}
