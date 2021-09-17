using System;
using System.Threading;
using Telegram.Bot;
using FluentScheduler;
using Monitora_Acoes.Crawler;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Collections.Generic;

namespace Monitora_Acoes.Main
{
    class Program
    {
        private static TelegramBotClient botcli;

        static void Main(string[] args)
        {
            var TelegramToken = @"settingsExt.txt";
            string token = File.ReadAllText(TelegramToken);

            botcli = new TelegramBotClient(token);
            botcli.OnMessage += BotClient_OnMessage;
            botcli.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botcli.StopReceiving();
        }

        static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var stocks = "petr3, taee4, aaaa2, sapr3";
            var gdc = new GetTextCrawler();
            List<string> retStocks = new List<string>();
            retStocks = gdc.Execute(stocks);

            var telegramId = e.Message.Chat.Id;
            foreach (var text in retStocks)
            {
                botcli.SendTextMessageAsync(
                e.Message.Chat.Id,
                $"{text}"
                );
            }
        }
    }
}
