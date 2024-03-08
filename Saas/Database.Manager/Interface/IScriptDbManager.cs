using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Interface
{
    public interface IScriptDbManager
    {
        ScriptReference InsertScript(ScriptReference script);
        List<ScriptReference> GetScriptByServiceReference(Guid serviceReferenceId);
    }
}
