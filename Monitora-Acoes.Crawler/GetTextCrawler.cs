using System.Net;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Monitora_Acoes.Crawler
{
    public class GetTextCrawler
    {
        public List<string> Execute(string stocks)
        {
            var stock = CutText(stocks);
            List<string> retStocks = new List<string>();
            foreach (var uniqueStock in stock)
                retStocks.Add(CrawlerStocks(uniqueStock));

            return retStocks;
        }

        public string CrawlerStocks(string stock)
        {
            using (WebClient wcli = new WebClient())
            {
                string msg = null;
                string site = wcli.DownloadString($"https://statusinvest.com.br/acoes/{stock}");

                var html = new HtmlDocument();
                html.LoadHtml(site);

                HtmlNode externalDiv = null;
                externalDiv = html.DocumentNode.SelectSingleNode("//*[@id='main-2']/div[2]/div/div[1]/div/div[1]");
                if (externalDiv == null)
                {
                    msg = stock + ": não encontrada."; //retornar como json
                }
                else
                {
                    var internalDiv = externalDiv.SelectNodes("//*[@id='main-2']/div[2]/div/div[1]/div/div[1]/div/div[1]/strong");

                    string price = null;
                    foreach (var node in internalDiv)
                        price = node.InnerHtml.ToString();

                    msg = stock + ": R$" + price; //retornar como json
                }
                return msg;
            }
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