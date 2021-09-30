using MongoDB.Driver;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.Data.Interfaces.Base
{
    public interface IBaseConnection
    {
        IMongoCollection<Stock> ConnectionDB();
    }
}