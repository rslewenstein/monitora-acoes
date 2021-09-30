using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Monitora_Acoes.Data.Interfaces;
using Monitora_Acoes.Data.Interfaces.Base;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Repositories
{
    public class StockDAO : IStocksDAO
    {
        private readonly IConfiguration _config;
        private readonly IBaseConnection _baseconn;
        public StockDAO(IConfiguration config, IBaseConnection baseconn)
        {
            _config = config;
            _baseconn = baseconn;
        }

        public JsonResult ListAllStock()
        {
            var db = _baseconn.ConnectionDB().AsQueryable();
            return new JsonResult(db);
        }

        public JsonResult ListStockByAcronym(string acronym)
        {
            var db = _baseconn.ConnectionDB()
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
            var db = _baseconn.ConnectionDB().AsQueryable();
            List<string> listChatId = new List<string>();
            foreach (var item in db)
                listChatId.Add(item.ChatId);

            return listChatId;
        }
        
        public JsonResult GetStocksByChatId(string chatid)
        {
            var db = _baseconn.ConnectionDB()
            .Find(x => x.ChatId == chatid).FirstOrDefault();
            return new JsonResult(db);
        }
    }
}