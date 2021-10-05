using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitora_Acoes.Bot;
using Monitora_Acoes.Bot.Interfaces;
using Monitora_Acoes.Data.Base;
using Monitora_Acoes.Data.Interfaces;
using Monitora_Acoes.Data.Interfaces.Base;
using Monitora_Acoes.Data.Repositories;
using Monitora_Acoes.Worker.Interfaces;

namespace Monitora_Acoes.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IProcessStock, ProcessStock>();
                    services.AddSingleton<IBotSendMessage, BotSendMessage>();
                    services.AddSingleton<IBotProcess, BotProcess>();
                    services.AddSingleton<IStocksDAO, StockDAO>();
                    services.AddSingleton<IBaseConnection, BaseConnection>();

                });
    }
}
