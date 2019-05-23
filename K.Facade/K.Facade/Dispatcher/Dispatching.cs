using K.Facade.Abstracts;
using K.Facade.Mapper;
using System;

namespace K.Facade.Dispatcher
{
	public class Dispatching : IDispatcher
	{
		private MappingCollection Mappings { get; }
		private IDispatcherInstancer Instancer { get; }

		public Dispatching(MappingCollection mappings, IDispatcherInstancer instancer)
		{
			Mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
			Instancer = instancer ?? throw new ArgumentNullException(nameof(instancer));
		}


		public virtual T GetInstance<T>()
		{
			return GetInstance<T>(null);
		}

		public virtual T GetInstance<T>(string target)
		{
			var mapping = Mappings.Get(typeof(T), target);

			if (mapping == null)
				throw new InterfaceNotMappedException(typeof(T), target);

			return (T)Instancer.GetInstance(mapping);
		}
	}
}
