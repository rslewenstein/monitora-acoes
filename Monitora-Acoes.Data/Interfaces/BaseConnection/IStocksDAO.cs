using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Interfaces.BaseConnection
{
    public interface IStocksDAO
    {
        void InsertStock(Stock stock);
        bool UpdateStock(Stock stock);
        bool DeleteStock(string id);
        List<Stock> ListStock();
    }
}