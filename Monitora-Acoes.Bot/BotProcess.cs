using System;
using Monitora_Acoes.Crawler;
using System.IO;
using System.Collections.Generic;
using System.Net;
using Monitora_Acoes.Bot.Interfaces;
using Monitora_Acoes.Data.Interfaces;

namespace Monitora_Acoes.Bot
{
    public class BotProcess : IBotProcess
    {
        private readonly IStocksDAO _stocksDAO;
        public BotProcess(IStocksDAO stocksDAO)
        {
            _stocksDAO = stocksDAO;
        }

        public List<string> ProcessMessage()
        {
            var stocks = GetListStocks();
            var gdc = new GetTextCrawler();
            List<string> stockAux = new List<string>();
            var retAux = CutText(stocks);
            foreach (var item in retAux)
            {
                stockAux = gdc.Execute(item.ToString());
                var t = GetPriceMinByStock(item.ToString());
            }
            // pegar as ações no banco
            // pegar o preço atual
            // vai comparar com o preço min
            // vai comparar com o preço max
            // se encontrar algo no min ou no max, chama o gdc.Execute
            // var gdc = new GetTextCrawler();
            List<string> retStocks = new List<string>();
            //retStocks = gdc.Execute(stocks);
            return retStocks;
        }
        // **********************************************************
        // Vai primeiro verificar a ação no site. 
        // Se estiver com o preço min ou max, vai pegar o id e enviar

        public string GetListStocks()
        {
            var listReturn = _stocksDAO.ListAllStock();
            string joinedString = string.Join(",", listReturn);
            return joinedString;
        }

        public string GetChatId()
        {
            var chatid = "";//_stocksDAO.GetChatId();
            return chatid;
        }

        public string GetPriceMinByStock(string stock)
        {

            // vai fazer um laço comparando o preço minimo e vai retornar msg com o preço se encontrar
            return null;
        }

        public string GetPriceMaxByStock(string stock)
        {

            // vai fazer um laço comparando o preço maximo e vai retornar msg com o preço se encontrar
            return null;
        }

        public List<string> CutText(string stocksList)
        {
            List<string> ret = new List<string>();
            string[] stock = stocksList.Split(',');

            foreach (var item in stock)
                ret.Add(item.Trim());

            return ret;
        }
    }
}