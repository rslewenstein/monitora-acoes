using System;
using System.IO;
using Telegram.Bot;
using FluentScheduler;
using Monitora_Acoes.Bot;

namespace Monitora_Acoes.Main
{
    class Program
    {
        private static string TelegramToken = @"settingsExt.txt";
        private static string token = File.ReadAllText(TelegramToken);

        static void Main(string[] args)
        {
            var bot = new BotSendMessage();
            bot.SendMessageTelegram(token);
        }
    }
}
