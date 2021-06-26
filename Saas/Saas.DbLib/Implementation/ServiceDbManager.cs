using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
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

        public List<ServiceReference> GetAllServices()
        {
            List<ServiceReference> result = new List<ServiceReference>();
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.ServiceReference.Where(i => i.Status.ToUpper() == "A").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public ServiceReference GetService(string controller, string action)
        {
            ServiceReference result = new ServiceReference();
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.ServiceReference.FirstOrDefault(i => i.Controller.ToUpper() == controller.ToUpper() && i.Action.ToUpper() == action.ToUpper());
                    if (result != null)
                        result.ScriptReferences = context.ScriptReference.Where(j => j.ServiceReferenceId == result.ServiceReferenceId && j.Status == "A").ToList();
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
