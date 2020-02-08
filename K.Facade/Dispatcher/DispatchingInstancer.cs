using K.Facade.Abstracts;
using K.Facade.Mapper;
using System;

namespace K.Facade.Dispatcher
{
	public class DispatchingInstancer : IDispatcherInstancer
	{
		public virtual object GetInstance(Mapping mapping)
		{
			if (mapping.Mode == MappingModeEnum.Instanced)
			{
				return mapping.Value;
			}
			else
			{
				return Activator.CreateInstance((Type)mapping.Value);
			}
		}
	}
}
