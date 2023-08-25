using System.Collections.Generic;

namespace Monitora_Acoes.Bot.Interfaces
{
    public interface IBotProcess
    {
        List<string> ProcessMessage();
        string GetTelegramChatId();
    }
}