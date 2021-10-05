using System.Collections.Generic;

namespace Monitora_Acoes.Bot.Interfaces
{
    public interface IBotProcess
    {
        List<string> ProcessMessage(string chatId);
        string GetListStocks();
        string GetChatId();
        string GetStockByChatId(string chatId);
        string GetPriceMinByStock(string stock);
        string GetPriceMaxByStock(string stock);
    }
}