using Saas.DbLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Common
{
    public static class BusinessUtil
    {
        public const string PreScript = "PRE";
        public const string PostScript = "POST";
        public static Dictionary<string, string> SetScript(IServiceDbManager serviceDbManager, string controllerName, string actionName)
        {
            Dictionary<string, string> scripts = new Dictionary<string, string>();
            var serviceDetails = serviceDbManager.GetService(controllerName.ToUpper(), actionName.ToUpper());
            if (serviceDetails != null
                && serviceDetails.ScriptReferences != null
                && serviceDetails.ScriptReferences.Any())
            {
                foreach (var scriptref in serviceDetails.ScriptReferences)
                {
                    scripts.Add(scriptref.ScriptType, scriptref.Script);
                }
            }

            return scripts;
        }
    }
}
