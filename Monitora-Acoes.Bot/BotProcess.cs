using System;
using Monitora_Acoes.Crawler;
using Monitora_Acoes.Crawler.Interfaces;
using System.Collections.Generic;
using Monitora_Acoes.Bot.Interfaces;
using Monitora_Acoes.Data.Interfaces;

namespace Monitora_Acoes.Bot
{
    public class BotProcess : IBotProcess
    {
        private readonly IStocksDAO _stocksDAO;
        private readonly IGetTextCrawler _getTextCrawler;
        public BotProcess(IStocksDAO stocksDAO, IGetTextCrawler getTextCrawler)
        {
            _stocksDAO = stocksDAO;
            _getTextCrawler = getTextCrawler;
        }

        public List<string> ProcessMessage()
        {
            var stocks = GetListStocks();
            string stockAux = null;
            var retAux = CutText(stocks);
            string retPriceMin = null;
            string retPriceMax = null;
            List<string> msg = new List<string>();
            foreach (var item in retAux)
            {
                stockAux = _getTextCrawler.Execute(item.ToString());
                if (!stockAux.Contains("não encontrada."))
                {
                    retPriceMin = GetPriceMinByStock(item.ToString(), stockAux);
                    retPriceMax = GetPriceMaxByStock(item.ToString(), stockAux);
                    if (!string.IsNullOrEmpty(retPriceMin))
                        msg.Add("A ação " + item.ToString().ToUpper() + " atingiu o preço mínimo setado de: " + retPriceMin);

                    if (!string.IsNullOrEmpty(retPriceMax))
                        msg.Add("A ação " + item.ToString().ToUpper() + " atingiu o preço máximo setado de: " + retPriceMax);
                }

            }
            return msg;
        }

        private string GetListStocks()
        {
            var listReturn = _stocksDAO.ListAllStock();
            string joinedString = string.Join(",", listReturn);
            return joinedString;
        }

        public string GetTelegramChatId()
        {
            var chatid = _stocksDAO.GetChatId();
            return chatid;
        }

        private string GetPriceMinByStock(string stock, string stockPrice)
        {
            var retAux = CutPrice(stockPrice);
            var priceNow = retAux[1].ToString();
            string priceMin = _stocksDAO.GetPriceMin(stock);
            string msg = null;
            if (Convert.ToDouble(priceNow) <= Convert.ToDouble(priceMin))
                msg = priceNow;

            return msg;
        }

        private string GetPriceMaxByStock(string stock, string stockPrice)
        {
            var retAux = CutPrice(stockPrice);
            var priceNow = retAux[1].ToString();
            string priceMax = _stocksDAO.GetPriceMax(stock);
            string msg = null;
            if (Convert.ToDouble(priceNow) >= Convert.ToDouble(priceMax))
                msg = priceNow;

            return msg;
        }

        private List<string> CutText(string stocksList)
        {
            List<string> ret = new List<string>();
            string[] stock = stocksList.Split(',');

            foreach (var item in stock)
                ret.Add(item.Trim());

            return ret;
        }

        private List<string> CutPrice(string stocksList)
        {
            List<string> ret = new List<string>();
            string[] stock = stocksList.Split('$');

            foreach (var item in stock)
                ret.Add(item.Trim());

            return ret;
        }
    }
}