using Microsoft.AspNetCore.Mvc;
using Saas.DbLib.Interface;
using Saas.Model.Service;
using Saas.Script.Interface;
using System;
using System.Linq;

namespace Saas.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDbManager _userDbManager;
        private readonly IServiceDbManager _serviceDbManager;
        private readonly IScriptManager _scriptManager;
        public UserController(IUserDbManager userDbManager, IServiceDbManager serviceDbManager, IScriptManager scriptManager)
        {
            _userDbManager = userDbManager;
            _serviceDbManager = serviceDbManager;
            _scriptManager = scriptManager;
        }

        [HttpPost]
        public UserModel AddUser([FromBody] UserModel user)
        {            
            var controllerName = this.ControllerContext.ActionDescriptor.ControllerName;
            var actionName = this.ControllerContext.ActionDescriptor.ActionName;

            #region Pre Script
            var serviceDetails = _serviceDbManager.GetService(controllerName, actionName);
            if (serviceDetails != null)
            {
                var preScript = serviceDetails.ScriptReferences.FirstOrDefault(i => i.ScriptType == "PRE");
                if (preScript != null && !String.IsNullOrWhiteSpace(preScript.Script))
                {
                    _scriptManager.ExecuteScript<UserModel>(preScript.Script, ref user);
                }
            }
            #endregion

            var result = _userDbManager.InsertUser(user);

            #region Post Script
            if (serviceDetails != null)
            {
                var postScript = serviceDetails.ScriptReferences.FirstOrDefault(i => i.ScriptType == "POST");
                if (postScript != null && !String.IsNullOrWhiteSpace(postScript.Script))
                {
                    _scriptManager.ExecuteScript<UserModel>(postScript.Script, ref result);
                }
            }
            #endregion

            return result;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
