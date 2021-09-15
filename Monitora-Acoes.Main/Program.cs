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

            //string stocks = "petr3, aaaa2, taee4, itsa4";
            string stocks = null;
            Console.WriteLine("Digite os códigos separados por vírgula. \nEx: abcd1, efgh2 \nou digite apenas um código. \nEx: bbbb3");
            Console.WriteLine("");
            stocks = Console.ReadLine();

            while (string.IsNullOrEmpty(stocks))
            {
                Console.WriteLine("Digite algum código para pesquisa.");
                Console.WriteLine("");
                Console.WriteLine("Digite os códigos separados por vírgula. \nEx: abcd1, efgh2 \nou digite apenas um código. \nEx: bbbb3");
                Console.WriteLine("");
                stocks = Console.ReadLine();
            }


            if (!string.IsNullOrEmpty(stocks))
            {
                var gdc = new GetDataCrawler();
                gdc.Execute(stocks);
            }
        }
    }
}
