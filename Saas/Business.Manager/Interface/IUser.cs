using Saas.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Interface
{
    public interface IUser
    {
        UserModel AddUser(UserModel user, string controller, string action);
        UserModel GetUser(string username, string controller, string action);
        UserModel GetUserById(Guid userId, string controller, string action);
    }
}
