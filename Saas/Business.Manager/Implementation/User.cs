using Saas.Business.Common;
using Saas.Business.Interface;
using Saas.DbLib.Interface;
using Saas.Model.Service;
using Saas.Script.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Implementation
{
    public class User : IUser
    {
        private readonly IUserDbManager _userDbManager;
        private readonly IServiceDbManager _serviceDbManager;
        private readonly IScriptManager _scriptManager;
        public User(IUserDbManager userDbManager, IServiceDbManager serviceDbManager, IScriptManager scriptManager)
        {
            _userDbManager = userDbManager;
            _serviceDbManager = serviceDbManager;
            _scriptManager = scriptManager;
        }

        public UserModel AddUser(UserModel user, string controller, string action)
        {
            var scripts = BusinessUtil.SetScript(_serviceDbManager, controller, action);

            #region Pre Script
            if (scripts.ContainsKey(BusinessUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.InsertUser(user);

            #region Post Script
            if (scripts.ContainsKey(BusinessUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PostScript], ref result);
            #endregion

            return result;
        }

        public UserModel GetUser(string username, string controller, string action)
        {
            var scripts = BusinessUtil.SetScript(_serviceDbManager, controller, action);

            UserModel user = new UserModel();
            #region Pre Script
            if (scripts.ContainsKey(BusinessUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.GetUserByUsername(username);

            #region Post Script
            if (scripts.ContainsKey(BusinessUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PostScript], ref result);
            #endregion

            return result;
        }

        public UserModel GetUserById(Guid userId, string controller, string action)
        {
            var scripts = BusinessUtil.SetScript(_serviceDbManager, controller, action);

            UserModel user = new UserModel();
            #region Pre Script
            if (scripts.ContainsKey(BusinessUtil.PreScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PreScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PreScript], ref user);
            #endregion

            var result = _userDbManager.GetUserById(userId);

            #region Post Script
            if (scripts.ContainsKey(BusinessUtil.PostScript) && !string.IsNullOrWhiteSpace(scripts[BusinessUtil.PostScript]))
                _scriptManager.ExecuteScript<UserModel>(scripts[BusinessUtil.PostScript], ref result);
            #endregion

            return result;
        }
    }
}
