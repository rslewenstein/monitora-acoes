using System.Collections.Generic;

namespace Monitora_Acoes.Bot.Interfaces
{
    public interface IBotProcess
    {
        List<string> ProcessMessage();
        string GetListStocks();
        string GetTelegramChatId();
        string GetPriceMinByStock(string stock, string stockPrice);
        string GetPriceMaxByStock(string stock, string stockPrice);
    }
}