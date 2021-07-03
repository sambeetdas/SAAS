using Microsoft.AspNetCore.Mvc;
using Saas.Business.Interface;
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
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public UserModel AddUser([FromBody] UserModel user)
        {
            var result = _user.AddUser(user, this.ControllerContext.ActionDescriptor.ControllerName, this.ControllerContext.ActionDescriptor.ActionName);
            return result;
        }

        [HttpGet]
        [Route("{username}")]
        public UserModel GetUser(string username)
        {
            var result = _user.GetUser(username, this.ControllerContext.ActionDescriptor.ControllerName, this.ControllerContext.ActionDescriptor.ActionName);
            return result;
        }

        [HttpGet]
        [Route("{userId}")]
        public UserModel GetUserById(Guid userId)
        {
            var result = _user.GetUserById(userId, this.ControllerContext.ActionDescriptor.ControllerName, this.ControllerContext.ActionDescriptor.ActionName);
            return result;
        }


    }
}
