using Saas.Model.Core;
using Saas.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Interface
{
    public interface IServiceDbManager
    {
        ServiceReference GetService(string controller, string action);
    }
}
