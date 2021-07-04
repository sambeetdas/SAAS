using Microsoft.AspNetCore.Mvc;
using Saas.Business.Interface;
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
        private readonly ISaasService _service;
        public ServiceController(ISaasService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<ServiceReference> GetAllServices()
        {
            var serviceDetails = _service.GetAllServices();
            return serviceDetails;
        }

        [HttpPost]
        public ScriptReference ValidateScript([FromBody] ScriptReference script)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }

            var validatedScript = _service.ValidateScript(script);
            return validatedScript;
        }

        [HttpPost]
        public ScriptReference AddScript([FromBody] ScriptReference script) //TODO : Add SubscriptionId as Param
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }

            var insertedScript = _service.AddScript(script);
            return insertedScript;
        }

        [HttpGet]
        [Route("{serviceReferenceId}")]
        public List<ScriptReference> GetServiceScript(Guid serviceReferenceId) //TODO : Add SubscriptionId as Param
        {
            var scripts = _service.GetServiceScript(serviceReferenceId);
            return scripts;
        }

    }
}
