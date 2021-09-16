using System;
using Telegram.Bot;
using System.Threading;

namespace Monitora_Acoes.Bot
{
    public class ConfigBot
    {
        private static TelegramBotClient botcli = new TelegramBotClient("1977380157:AAESASXTz_DdJMzKAILzImVe2W8VzH5nadg");
        public void ExecuteBot(string stocks)
        {
            botcli.OnMessage += BotClient_OnMessage;

            botcli.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botcli.StopReceiving();
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
        }
    }
}