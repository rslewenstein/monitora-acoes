using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using FluentScheduler;
using Monitora_Acoes.Crawler;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitora_Acoes.Main
{
    class Program
    {
        private static string TelegramToken = @"settingsExt.txt";
        private static string token = File.ReadAllText(TelegramToken);
        private static string chatId = YOUR_ID;

        static void Main(string[] args)
        {
            SendMessageTelegram(token, chatId);
        }


        public static void SendMessageTelegram(string token, string chatId)
        {
            string apiToken = token;
            List<string> stocks = ProcessMessage(chatId);

            foreach (var stock in stocks)
            {
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                urlString = String.Format(urlString, apiToken, chatId, stock);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
            }
        }

        public static List<string> ProcessMessage(string chatId)
        {
            var stocks = "petr3, taee4, aaaa2, sapr3";
            var gdc = new GetTextCrawler();
            List<string> retStocks = new List<string>();
            String IdAux = chatId;
            retStocks = gdc.Execute(stocks);
            return retStocks;
        }

    }
}
