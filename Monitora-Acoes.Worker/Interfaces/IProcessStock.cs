using System.Threading.Tasks;

namespace Monitora_Acoes.Worker.Interfaces
{
    public interface IProcessStock
    {
        Task SearchStocks();
        Task Executar();
    }
}