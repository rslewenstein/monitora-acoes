using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitora_Acoes.Interfaces.Worker;
using Monitora_Acoes.Worker.Interfaces;

namespace Monitora_Acoes.Worker
{
    public class BackgroundWorker : IHostedService
    {
        private readonly ILogger<BackgroundWorker> _logger;
        private readonly IWorker _worker;
      //  private readonly IProcessStock _process;
        public BackgroundWorker(ILogger<BackgroundWorker> logger, IWorker worker)//, IProcessStock process)
        {
            _logger = logger;
            _worker = worker;
           // _process = process;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
           // await _process.Executar();
            await _worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("App stopping");
            return Task.CompletedTask;
        }
    }
}