using System;
using FluentScheduler;
using Monitora_Acoes.Crawler;

namespace Monitora_Acoes.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            JobManager.Initialize(new ConfigurationCrawler());
            Console.ReadLine();
        }
    }
}
