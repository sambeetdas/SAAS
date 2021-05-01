using Saas.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Interface
{
    public interface IUserDbManager
    {
        UserModel InsertUser(UserModel user);
        UserModel GetUserById(Guid userId);
        UserModel GetUserByUsername(string username);
    }
}
