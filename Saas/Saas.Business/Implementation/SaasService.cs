using Saas.Business.Interface;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Implementation
{
    public class SaasService : ISaasService
    {
        private readonly IServiceDbManager _serviceDbManager;
        private readonly IScriptDbManager _scriptDbManager;
        public SaasService(IServiceDbManager serviceDbManager, IScriptDbManager scriptDbManager)
        {
            _serviceDbManager = serviceDbManager;
            _scriptDbManager = scriptDbManager;
        }

        public List<ServiceReference> GetAllServices()
        {
            var serviceDetails = _serviceDbManager.GetAllServices();
            return serviceDetails;
        }

        public ScriptReference AddScript(ScriptReference script)
        {
            var insertedScript = _scriptDbManager.InsertScript(script);
            return insertedScript;
        }

        public List<ScriptReference> GetServiceScript(Guid serviceReferenceId)
        {
            var scripts = _scriptDbManager.GetScriptByServiceReference(serviceReferenceId);
            return scripts;
        }
    }
}
