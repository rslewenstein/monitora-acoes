using System;
using Telegram.Bot;
using System.Threading;

namespace Monitora_Acoes.Bot
{
    public class ConfigBot
    {
        private static TelegramBotClient botcli = new TelegramBotClient("TOKEN");
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