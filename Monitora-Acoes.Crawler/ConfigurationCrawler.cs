using System;
using FluentScheduler;

namespace Monitora_Acoes.Crawler
{
    public class ConfigurationCrawler : Registry
    {
        public ConfigurationCrawler()
        {
            // Schedule<GetDataCrawler>()
            //     .NonReentrant()
            //     .ToRunOnceAt(DateTime.Now.AddSeconds(3))
            //     .AndEvery(10).Seconds(); //60 seconds
        }
    }
}