using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Monitora_Acoes.Interfaces.Worker;

namespace Monitora_Acoes.Worker
{
    public class DerivedBackgroundWorker : BackgroundService
    {
        private readonly IWorker _worker;
        public DerivedBackgroundWorker(IWorker worker)
        {
            _worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}