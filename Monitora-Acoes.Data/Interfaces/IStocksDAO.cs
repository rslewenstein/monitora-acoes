using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Interfaces
{
    public interface IStocksDAO
    {
        void InsertStock(Stock stock);
        bool UpdateStock(Stock stock);
        bool DeleteStock(string id);
        List<string> ListAllStock();
        JsonResult ListAllStockJSON();
        JsonResult ListStockByAcronym(string acronym);

        string GetChatId();
        JsonResult GetStocksByChatId(string chatid);
        string GetPriceMin(string stock);
        string GetPriceMax(string stock);
    }
}