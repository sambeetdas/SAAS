using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Linq;

namespace Saas.DbLib.Implementation
{
    public class ServiceDbManager : IServiceDbManager
    {
        private readonly string _sqlConnectionStr;
        public ServiceDbManager(string sqlConnectionStr)
        {
            _sqlConnectionStr = sqlConnectionStr;
        }

        public ServiceReference GetService(string controller, string action)
        {
            dynamic result = null;
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.ServiceReference.FirstOrDefault(i => i.Controller.ToUpper() == controller.ToUpper() && i.Action.ToUpper() == action.ToUpper()).ScriptReferences.FirstOrDefault(j => j.Status == "A");
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
