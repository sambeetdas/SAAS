using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Script.Interface
{
    public interface IScriptManager
    {
        void ExecuteScript<T>(string serviceScript, ref T input);
    }
}
