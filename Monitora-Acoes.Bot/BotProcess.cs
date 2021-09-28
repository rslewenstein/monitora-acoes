using System;
using Monitora_Acoes.Crawler;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace Monitora_Acoes.Bot
{
    public class BotProcess // Essa classe irá fazer a chamada no projeto DATA e manipular as informações
    {
        public List<string> ProcessMessage(string chatId)
        {
            var stocks = GetStockByChatId(chatId);
            var gdc = new GetTextCrawler();
            List<string> retStocks = new List<string>();
            String IdAux = chatId;
            retStocks = gdc.Execute(stocks);
            return retStocks;
        }

        public string GetChatId() // Irá pegar o chatId
        {
            string chatid = "CHAT_ID";

            return chatid;
        }

        public string GetStockByChatId(string chatId)
        {
            // vai pegar todas as ações cadastradas no chatid e buscar no site.
            // vai trazer o preço atual de todas.
            var stocks = "petr3, taee4, aaaa2, sapr3";

            return stocks;
        }

        public string GetPriceMinByStock(string stock)
        {
            // vai fazer um laço comparando o preço minimo e vai retornar msg se encontrar
            return null;
        }

        public string GetPriceMaxByStock(string stock)
        {
            // vai fazer um laço comparando o preço maximo e vai retornar msg se encontrar
            return null;
        }
    }
}