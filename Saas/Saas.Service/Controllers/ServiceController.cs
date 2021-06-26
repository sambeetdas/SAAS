using Microsoft.AspNetCore.Mvc;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saas.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceDbManager _serviceDbManager;
        private readonly IScriptDbManager _scriptDbManager;
        public ServiceController(IServiceDbManager serviceDbManager, IScriptDbManager scriptDbManager)
        {
            _serviceDbManager = serviceDbManager;
            _scriptDbManager = scriptDbManager;
        }

        [HttpGet]
        public List<ServiceReference> GetAllServices()
        {
            var serviceDetails = _serviceDbManager.GetAllServices();
            return serviceDetails;
        }

        [HttpPost]
        public ScriptReference AddScript([FromBody] ScriptReference script)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }

            var insertedScript = _scriptDbManager.InsertScript(script);
            return insertedScript;
        }

        [HttpGet]
        [Route("{serviceReferenceId}")]
        public List<ScriptReference> GetServiceScript(Guid serviceReferenceId)
        {
            var scripts = _scriptDbManager.GetScriptByServiceReference(serviceReferenceId);
            return scripts;
        }
    }
}
