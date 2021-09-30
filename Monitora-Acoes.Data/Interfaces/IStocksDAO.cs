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
        JsonResult ListAllStock();
        JsonResult ListStockByAcronym(string acronym);

        List<string> GetChatId();
        JsonResult GetStocksByChatId(string chatid);
    }
}