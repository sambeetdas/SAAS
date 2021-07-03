using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Interface
{
    public interface ISaasService
    {
        List<ServiceReference> GetAllServices();
        ScriptReference AddScript(ScriptReference script);
        List<ScriptReference> GetServiceScript(Guid serviceReferenceId);
    }
}
