using System;
using System.IO;
using Monitora_Acoes.Bot;
using System.Threading;
using System.Threading.Tasks;

namespace Monitora_Acoes.Worker
{
    public class ProcessStock
    {
        private static string TelegramToken = @"settingsExt.txt";
        private static string token = File.ReadAllText(TelegramToken);

        public async Task Executar()
        {
            await SearchStocks();
        }

        public Task SearchStocks()
        {
            var bot = new BotSendMessage();
            bot.SendMessageTelegram(token);
            return null;
        }
    }
}