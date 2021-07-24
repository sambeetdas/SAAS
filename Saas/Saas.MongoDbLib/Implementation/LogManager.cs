using MongoDB.Driver;
using Saas.Model.Core;
using Saas.MongoDbLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.MongoDbLib.Implementation
{
    public class LogManager : ILogManager
    {
        private readonly IMongoCollection<LogModel> _log;
        public LogManager(MongoDbSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _log = database.GetCollection<LogModel>(settings.CollectionName);
        }

        public async Task InsertLog(LogModel logModel)
        {
            await _log.InsertOneAsync(logModel);
        }
    }
}
