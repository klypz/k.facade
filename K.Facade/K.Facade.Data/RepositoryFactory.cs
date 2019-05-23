using K.Facade.Abstracts;
using K.Facade.Data.Dispatcher;
using K.Facade.Data.Repository;
using K.Facade.Dispatcher;
using K.Facade.Mapper;
using System.Data.Common;

namespace K.Facade.Data
{
	public static class RepositoryFactory
	{
		private static MappingCollection Mappings { get; } = new MappingCollection();
		private static DispatchingRepository Dispatcher { get; } = new DispatchingRepository(Mappings, new DispatchingInstancer());
		public static IMappingFactory Mapper { get; } = new MappingRepositoryFactory(Mappings, "repository", typeof(SetRepositoryAttribute));

		public static T GetInstance<T>()
		{
			return Dispatcher.GetInstance<T>();
		}
		public static T GetInstance<T>(string target)
		{
			return Dispatcher.GetInstance<T>(target);
		}

		public static T GetInstance<T>(DbConnection dbConnection)
		{
			return Dispatcher.GetInstance<T>(dbConnection);
		}
		public static T GetInstance<T>(DbTransaction dbTransaction)
		{
			return Dispatcher.GetInstance<T>(dbTransaction);
		}
		public static T GetInstance<T>(IRepository repository)
		{
			return Dispatcher.GetInstance<T>(repository);
		}
		public static T GetInstance<T>(DbConnection dbConnection, string target)
		{
			return Dispatcher.GetInstance<T>(dbConnection, target);
		}
		public static T GetInstance<T>(DbTransaction dbTransaction, string target)
		{
			return Dispatcher.GetInstance<T>(dbTransaction, target);
		}
		public static T GetInstance<T>(IRepository repository, string target)
		{
			return Dispatcher.GetInstance<T>(repository, target);
		}

	}
}
