using Saas.DbLib.Interface;
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
    }
}
