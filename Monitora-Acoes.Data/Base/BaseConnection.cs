using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Monitora_Acoes.Data.Interfaces.Base;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Base
{
    public class BaseConnection : IBaseConnection
    {
        private readonly IConfiguration _config;
        public BaseConnection(IConfiguration config)
        {
            _config = config;
        }
        public IMongoCollection<Stock> ConnectionDB()
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            IMongoCollection<Stock> ret = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit");
            return ret;
        }
    }
}