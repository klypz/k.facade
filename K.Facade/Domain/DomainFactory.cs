using K.Facade.Abstracts;
using K.Facade.Dispatcher;
using K.Facade.Mapper;

namespace K.Facade.Domain
{
	public static class DomainFactory
	{
		private static MappingCollection Mappings { get; } = new MappingCollection();
		private static IDispatcher Dispatcher { get; } = new Dispatching(Mappings, new DispatchingInstancer());
		public static IMappingFactory Mapper { get; } = new MappingFactory(Mappings, "domain", typeof(SetFacadeAttribute));

		public static T GetInstance<T>()
		{
			return Dispatcher.GetInstance<T>();
		}
		public static T GetInstance<T>(string target)
		{
			return Dispatcher.GetInstance<T>(target);
		}
	}
}
