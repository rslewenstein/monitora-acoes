using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Monitora_Acoes.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ProcessStock _processStock;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _processStock = new ProcessStock();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                // await Task.Delay(1000, stoppingToken);
                await _processStock.Executar();
            }
        }
    }
}
