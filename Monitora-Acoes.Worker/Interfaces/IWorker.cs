using System.Threading;
using System.Threading.Tasks;

namespace Monitora_Acoes.Interfaces.Worker
{
    public interface IWorker
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}