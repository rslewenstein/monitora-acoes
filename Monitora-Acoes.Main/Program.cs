using System;
using System.Threading;
using FluentScheduler;
using Monitora_Acoes.Crawler;

namespace Monitora_Acoes.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // JobManager.Initialize(new ConfigurationCrawler());
            // Console.ReadLine();

            //string stocks = "petr3, aaaa2, taee4, itsa4";
            Console.WriteLine("Digite os códigos separados por vírgula. \nEx: abcd1, efgh2 \nou digite apenas um código. \nEx: bbbb3");
            Console.WriteLine("");
            var stocks = Console.ReadLine();

            while (string.IsNullOrEmpty(stocks))
            {
                Console.WriteLine("Digite algum código para pesquisa.");
                Console.WriteLine("");
                stocks = Console.ReadLine();
            }


            if (!string.IsNullOrEmpty(stocks))
            {
                var gdc = new GetDataCrawler();
                int cont = 1;

                while (cont > 0)
                {
                    try
                    {
                        gdc.Execute(stocks);
                        Thread.Sleep(30000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ops... " + ex.ToString());
                        cont = 0;
                    }
                }

            }
        }
    }
}
