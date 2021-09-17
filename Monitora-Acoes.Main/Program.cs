using System;
using System.Threading;
using Telegram.Bot;
using FluentScheduler;
using Monitora_Acoes.Crawler;
using Monitora_Acoes.Bot;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Monitora_Acoes.Main
{
    class Program
    {
        private static TelegramBotClient botcli;

        static void Main(string[] args)
        {
            var _File = @"settingsExt.txt";
            string text = File.ReadAllText(_File);
            botcli = new TelegramBotClient(text);
            botcli.OnMessage += BotClient_OnMessage;

            botcli.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botcli.StopReceiving();
        }

        static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            // var stocks = "petr3, taee4, aaaa2, snpr3"; //e.Message.Text;
            var telegramId = e.Message.Chat.Id;

            // while (string.IsNullOrEmpty(stocks))
            // {
            //     botcli.SendTextMessageAsync(
            //         e.Message.Chat.Id,
            //         $"Olá {e.Message.From.FirstName}, digite algum código."
            //     );
            // }

            // if (!string.IsNullOrEmpty(stocks))
            // {
            // var gdc = new GetTextCrawler();
            // string StopCrawler = stocks;

            // while (StopCrawler != null)
            // {
            //     try
            //     {
            //         var ret = gdc.Execute(stocks);
            //         botcli.SendTextMessageAsync(
            //             e.Message.Chat.Id,
            //             $"{ret}"
            //         );
            //         Thread.Sleep(30000); //30000
            //     }
            //     catch (Exception ex)
            //     {
            //         Console.WriteLine("Ops... " + ex.ToString());
            //         StopCrawler = null;
            //     }
            // }
            // }
            botcli.SendTextMessageAsync(
                e.Message.Chat.Id,
                $"Olá {e.Message.Chat.Id}, nome = {e.Message.From.FirstName}"
                );
        }
    }
}
