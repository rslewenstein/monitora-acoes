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

        public JsonResult ListAllStockJSON()
        {
            var db = _baseconn.ConnectionDB().AsQueryable();
            return new JsonResult(db);
        }

        public List<string> ListAllStock()
        {
            var db = _baseconn.ConnectionDB().AsQueryable();
            List<string> liststocks = new List<string>();
            foreach (var item in db)
                liststocks.Add(item.Acronym);

            return liststocks;
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

        string IStocksDAO.GetChatId()
        {
            var db = _baseconn.ConnectionDB().AsQueryable().FirstOrDefault();
            string chatid = db.ChatId;
            return chatid;
        }

        public string GetPriceMin(string stock)
        {
            var db = _baseconn.ConnectionDB()
            .Find(x => x.Acronym == stock);
            string aux = null;
            foreach (var item in db.ToList())
                aux = item.PriceMin;

            return aux;
        }

        public string GetPriceMax(string stock)
        {
            var db = _baseconn.ConnectionDB()
            .Find(x => x.Acronym == stock);
            string aux = null;
            foreach (var item in db.ToList())
                aux = item.PriceMax;

            return aux;
        }
    }
}