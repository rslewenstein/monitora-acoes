using System.Net;
using FluentScheduler;
using HtmlAgilityPack;
using System;

namespace Monitora_Acoes.Crawler
{
    public class GetDataCrawler : IJob
    {
        private string vtest = "petr3"; //MOC - retirar
        public void Execute()
        {
            using (WebClient wcli = new WebClient())
            {
                string google = wcli.DownloadString($"https://statusinvest.com.br/acoes/{vtest}");

                var html = new HtmlDocument();
                html.LoadHtml(google);

                var externalDiv = html.DocumentNode.SelectSingleNode("//*[@id='main-2']/div[2]/div/div[1]/div/div[1]");
                var internalDiv = externalDiv.SelectNodes("//*[@id='main-2']/div[2]/div/div[1]/div/div[1]/div/div[1]/strong");

                string price = null;
                foreach (var node in internalDiv)
                {
                    price = node.InnerHtml.ToString();
                }

                Console.WriteLine(vtest + ": " + price);
                Console.ReadLine();
            }
        }
    }
}