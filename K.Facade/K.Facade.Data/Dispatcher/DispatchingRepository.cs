using K.Facade.Abstracts;
using K.Facade.Data.Abstracts;
using K.Facade.Data.Repository;
using K.Facade.Dispatcher;
using K.Facade.Mapper;
using System.Data.Common;

namespace K.Facade.Data.Dispatcher
{
	class DispatchingRepository : Dispatching, IDispatcherRepository
	{
		public DispatchingRepository(MappingCollection mappings, IDispatcherInstancer instancer) : base(mappings, instancer)
		{
		}

		public new T GetInstance<T>()
		{
			return GetInstance<T>(RepositoryConfiguration.GetConnection() ?? null);
		}

		public new T GetInstance<T>(string target)
		{
			return GetInstance<T>(RepositoryConfiguration.GetConnection() ?? null, target);
		}


		public T GetInstance<T>(DbConnection dbConnection)
		{
			return GetInstance<T>(dbConnection, null);
		}

		public T GetInstance<T>(DbTransaction dbTransaction)
		{
			return GetInstance<T>(dbTransaction, null);
		}

		public T GetInstance<T>(IRepository repository)
		{
			return GetInstance<T>(repository, null);
		}

		public T GetInstance<T>(DbConnection dbConnection, string target)
		{
			IRepository result = (IRepository)base.GetInstance<T>(target);
			result.Connection = dbConnection;

			return (T)result;
		}

		public T GetInstance<T>(DbTransaction dbTransaction, string target)
		{
			IRepository result = (IRepository)base.GetInstance<T>(target);
			result.Connection = dbTransaction.Connection;
			result.Transaction = dbTransaction;

			return (T)result;
		}

		public T GetInstance<T>(IRepository repository, string target)
		{
			IRepository result = (IRepository)base.GetInstance<T>(target);
			result.Connection = repository.Connection;
			result.Transaction = repository.Transaction;

			return (T)result;
		}
	}
}
