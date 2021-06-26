using Microsoft.AspNetCore.Mvc;
using Saas.DbLib.Interface;
using Saas.Model.Service;
using Saas.Script.Interface;
using Saas.Service.Common;
using System;

namespace Saas.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
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
            var scripts = ServiceUtil.SetScript(_serviceDbManager,
                                                this.ControllerContext.ActionDescriptor.ControllerName,
                                                this.ControllerContext.ActionDescriptor.ActionName);

            #region Pre Script
            if (scripts.ContainsKey(ServiceUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.InsertUser(user);

            #region Post Script
            if (scripts.ContainsKey(ServiceUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PostScript], ref result);
            #endregion

            return result;
        }

        [HttpGet]
        [Route("{username}")]
        public UserModel GetUser(string username)
        {
            var scripts = ServiceUtil.SetScript(_serviceDbManager,
                                                this.ControllerContext.ActionDescriptor.ControllerName,
                                                this.ControllerContext.ActionDescriptor.ActionName);

            UserModel user = new UserModel();
            #region Pre Script
            if (scripts.ContainsKey(ServiceUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.GetUserByUsername(username);

            #region Post Script
            if (scripts.ContainsKey(ServiceUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PostScript], ref result);
            #endregion

            return result;
        }

        [HttpGet]
        [Route("{userId}")]
        public UserModel GetUserById(Guid userId)
        {
            var scripts = ServiceUtil.SetScript(_serviceDbManager,
                                                this.ControllerContext.ActionDescriptor.ControllerName,
                                                this.ControllerContext.ActionDescriptor.ActionName);

            UserModel user = new UserModel();
            #region Pre Script
            if (scripts.ContainsKey(ServiceUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.GetUserById(userId);

            #region Post Script
            if (scripts.ContainsKey(ServiceUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[ServiceUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[ServiceUtil.PostScript], ref result);
            #endregion

            return result;
        }


    }
}
