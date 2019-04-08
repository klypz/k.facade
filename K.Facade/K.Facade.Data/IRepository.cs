using System.Data.Common;

namespace K.Facade.Data
{
    public interface IRepository
    {
        DbConnection Connection { get; }
        bool IsOwner { get; }
        DbTransaction Transaction { get; }
    }
}