using System.Data.Common;
using K.Facade.Data.Repository;
namespace K.Facade.Data
{
	public interface IRepositoryFactory : IFactory
	{
		T GetInstance<T>(DbConnection dbConnection);
		T GetInstance<T>(DbTransaction dbConnection);
		T GetInstance<T>(IRepository dbConnection);

		T GetInstance<T>(DbConnection dbConnection, string target);
		T GetInstance<T>(DbTransaction dbConnection, string target);
		T GetInstance<T>(IRepository dbConnection, string target);
	}
}
