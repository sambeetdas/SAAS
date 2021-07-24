using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.MongoDbLib.Interface
{
    public interface ILogManager
    {
        Task InsertLog(LogModel logModel);
    }
}
