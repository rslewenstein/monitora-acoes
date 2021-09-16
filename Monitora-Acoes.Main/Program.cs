using System;
using System.Threading;
using Telegram.Bot;
using FluentScheduler;
using Monitora_Acoes.Crawler;
using Monitora_Acoes.Bot;

namespace Monitora_Acoes.Main
{
    class Program
    {
        private static TelegramBotClient botcli = new TelegramBotClient("TOKEN");
        static void Main(string[] args)
        {
            // JobManager.Initialize(new ConfigurationCrawler());
            // Console.ReadLine();

            botcli.OnMessage += BotClient_OnMessage;

            botcli.StartReceiving();
            Thread.Sleep(Timeout.Infinite);
            botcli.StopReceiving();


            // //string stocks = "petr3, aaaa2, taee4, itsa4";
            // Console.WriteLine("Digite os códigos separados por vírgula. \nEx: abcd1, efgh2 \nou digite apenas um código. \nEx: bbbb3");
            // Console.WriteLine("");
            // var stocks = Console.ReadLine();
            // // var bot = new ConfigBot();
            // // bot.ExecuteBot(stocks);

            // while (string.IsNullOrEmpty(stocks))
            // {
            //     Console.WriteLine("Digite algum código para pesquisa.");
            //     Console.WriteLine("");
            //     stocks = Console.ReadLine();
            // }


            // if (!string.IsNullOrEmpty(stocks))
            // {
            //     var gdc = new GetDataCrawler();
            //     int cont = 1;

            //     while (cont > 0)
            //     {
            //         try
            //         {
            //             gdc.Execute(stocks);
            //             Thread.Sleep(30000);
            //         }
            //         catch (Exception ex)
            //         {
            //             Console.WriteLine("Ops... " + ex.ToString());
            //             cont = 0;
            //         }
            //     }

            // }
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var stocks = e.Message.Text;
            var telegramId = e.Message.Chat.Id;

            while (string.IsNullOrEmpty(stocks))
            {
                // Console.WriteLine("Digite algum código para pesquisa.");
                // Console.WriteLine("");
                // stocks = Console.ReadLine();
                botcli.SendTextMessageAsync(
                    $"Olá {e.Message.From.FirstName}, digite algum código."
                );
            }

            if (!string.IsNullOrEmpty(stocks))
            {
                var gdc = new GetDataCrawler();
                int cont = 1;

                while (cont > 0)
                {
                    try
                    {
                        gdc.Execute(stocks);
                        Thread.Sleep(30000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ops... " + ex.ToString());
                        cont = 0;
                    }
                }

            }
        }
    }
}
