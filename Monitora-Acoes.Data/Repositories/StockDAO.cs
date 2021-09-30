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
        public bool DeleteStock(string id)
        {
            throw new System.NotImplementedException();
        }

        public void InsertStock(Stock stock)
        {
            throw new System.NotImplementedException();
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

        public bool UpdateStock(Stock stock)
        {
            throw new System.NotImplementedException();
        }
    }
}