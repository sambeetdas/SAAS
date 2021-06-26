using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Implementation
{
    public class ScriptDbManager : IScriptDbManager
    {
        private readonly string _sqlConnectionStr;
        public ScriptDbManager(string sqlConnectionStr)
        {
            _sqlConnectionStr = sqlConnectionStr;
        }

        public ScriptReference InsertScript(ScriptReference script)
        {
            List<ScriptReference> scriptsForService = new List<ScriptReference>();
            ScriptReference scriptForType = new ScriptReference();
            try
            {
                scriptsForService = GetScriptByServiceReference(script.ServiceReferenceId);

                if (scriptsForService != null)
                {
                    scriptForType = scriptsForService.FirstOrDefault(s => s.ScriptType == script.ScriptType);
                    
                    if (scriptForType != null)
                        scriptForType.Status = "I";
                }

                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    if (scriptForType != null)
                        context.Update<ScriptReference>(scriptForType);

                    context.Add<ScriptReference>(script);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }


        public List<ScriptReference> GetScriptByServiceReference(Guid serviceReferenceId)
        {
            List<ScriptReference> result = new List<ScriptReference>();
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.ScriptReference.Where(i => i.ServiceReferenceId == serviceReferenceId && i.Status.ToUpper() == "A").ToList();
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
