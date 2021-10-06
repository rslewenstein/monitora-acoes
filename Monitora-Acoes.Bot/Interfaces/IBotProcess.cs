using System.Collections.Generic;

namespace Monitora_Acoes.Bot.Interfaces
{
    public interface IBotProcess
    {
        List<string> ProcessMessage();
        string GetListStocks();
        string GetChatId();
        string GetPriceMinByStock(string stock);
        string GetPriceMaxByStock(string stock);
    }
}