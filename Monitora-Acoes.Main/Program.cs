using System;
using FluentScheduler;
using Monitora_Acoes.Crawler;

namespace Monitora_Acoes.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deverá receber um ou mais códigos de ações e pesquisar.
            // Talvez será necessário utilizar o Sleep
            // e chamar o método direto na classe GetDataCrawler

            // JobManager.Initialize(new ConfigurationCrawler());
            // Console.ReadLine();

            var gdc = new GetDataCrawler();
            gdc.Execute();
        }
    }
}
