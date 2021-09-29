using System.Data;

namespace Monitora_Acoes.Data.Interfaces.BaseConnection
{
    public interface IConnFactory
    {
        IDbConnection Connection();
    }
}