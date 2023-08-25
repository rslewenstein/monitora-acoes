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
            IMongoCollection<Stock> result = null;
            try
            {
                MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
                result = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco: " + ex.Message);
            }
            
            return result;
        }
    }
}