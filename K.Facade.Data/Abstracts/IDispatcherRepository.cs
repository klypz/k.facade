using K.Facade.Data.Repository;
using System.Data.Common;

namespace K.Facade.Data.Abstracts
{
	interface IDispatcherRepository
	{
		T GetInstance<T>(DbConnection dbConnection);
		T GetInstance<T>(DbTransaction dbTransaction);
		T GetInstance<T>(IRepository repository);

		T GetInstance<T>(DbConnection dbConnection, string target);
		T GetInstance<T>(DbTransaction dbTransaction, string target);
		T GetInstance<T>(IRepository repository, string target);
	}
}
