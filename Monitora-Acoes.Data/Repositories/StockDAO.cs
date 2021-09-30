using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Monitora_Acoes.Data.Interfaces;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Repositories
{
    public class StockDAO : IStocksDAO
    {
        private readonly IConfiguration _config;
        public StockDAO(IConfiguration config)
        {
            _config = config;
        }

        public JsonResult ListAllStock()
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            var dbList = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit").AsQueryable();
            return new JsonResult(dbList);
        }

        public JsonResult ListStockByAcronym(string acronym)
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            var db = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit")
            .Find(x => x.Acronym == acronym).FirstOrDefault();
            return new JsonResult(db);
        }

        public void InsertStock(Stock stock)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateStock(Stock stock)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteStock(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetChatId()
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            var db = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit").AsQueryable();
            List<string> listChatId = new List<string>();
            foreach (var item in db)
            {
                listChatId.Add(item.ChatId);
            }
            return listChatId;
        }
        public JsonResult GetStocksByChatId(string chatid)
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            var db = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit")
            .Find(x => x.ChatId == chatid).FirstOrDefault();
            return new JsonResult(db);
        }
    }
}