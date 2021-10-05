using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitora_Acoes.Interfaces.Worker;
using Monitora_Acoes.Worker.Interfaces;

namespace Monitora_Acoes.Worker
{
    public class WorkerService : IWorker
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IProcessStock _processStock;

        public WorkerService(ILogger<WorkerService> logger, IProcessStock processStock)
        {
            _logger = logger;
            _processStock = processStock;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                // await Task.Delay(1000, stoppingToken);
                await _processStock.Executar();
                await Task.Delay(20000);
            }
        }
    }
}
