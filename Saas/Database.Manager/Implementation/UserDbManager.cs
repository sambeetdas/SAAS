using Saas.DbLib.Interface;
using Saas.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Implementation
{
    public class UserDbManager : IUserDbManager
    {
        private readonly string _sqlConnectionStr;
        public UserDbManager(string sqlConnectionStr)
        {
            _sqlConnectionStr = sqlConnectionStr;
        }
        public UserModel InsertUser(UserModel user)
        {
            try
            {
                var userByName = GetUserByUsername(user.UserName);
                if (userByName == null)
                {
                    using (var context = new SaasDbContext(_sqlConnectionStr))
                    {
                        context.Add<UserModel>(user);
                        context.SaveChanges();
                    }

                    return user;
               }               
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public UserModel GetUserById(Guid userId)
        {
            dynamic result = null;
            try
            {                
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.UserModel.FirstOrDefault(i => i.UserId == userId);
                }                
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public UserModel GetUserByUsername(string username)
        {
            dynamic result = null;
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.UserModel.FirstOrDefault(i => i.UserName.ToUpper() == username.ToUpper());
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return result;
        }
    }
}
