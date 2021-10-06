using System;
using System.IO;
using System.Threading.Tasks;
using Monitora_Acoes.Bot.Interfaces;
using Monitora_Acoes.Worker.Interfaces;

namespace Monitora_Acoes.Worker
{
    public class ProcessStock : IProcessStock
    {
        private readonly IBotSendMessage _bot;
        public ProcessStock(IBotSendMessage bot)
        {
            _bot = bot;
        }
        private static string TelegramToken = @"settingsExt.txt";
        private static string token = File.ReadAllText(TelegramToken);

        public async Task Executar()
        {
            await SearchStocks();
        }

        public async Task SearchStocks()
        {
            _bot.SendMessageTelegram(token);
        }

        // public Task SearchStocks()
        // {
        //     _bot.SendMessageTelegram(token);
        //     return null;
        // }
    }
}