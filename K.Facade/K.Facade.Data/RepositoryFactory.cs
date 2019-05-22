using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using K.Facade.Data.Repository;
using K.Facade.Structure;
using DOM = K.Facade.Data.Repository;
namespace K.Facade.Data
{

	internal class RepositoryFactory : FacadeFactoryBase, IRepositoryFactory
	{
		public RepositoryFactory() : base(new RepositoryMapper(), new DOM.RepositoryFactory(), new MappingCollection())
		{
			((RepositoryMapper)FacadeMapper).SetMappings(_mappings);
			((DOM.RepositoryFactory)FacadeFactory).SetMappings(_mappings);
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
