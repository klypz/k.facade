using K.Facade.Structure;
using System;

namespace K.Facade.DomainService
{
	public class FacadeFactory : IFacadeFactory
	{
		private MappingCollection _mapping;

		public T GetInstance<T>()
		{
			return GetInstance<T>(null);
		}

		public T GetInstance<T>(string target)
		{
			var mapping = _mapping.Get(typeof(T), target);
			if (mapping.Mode == MappingModeEnum.Instanced)
			{
				return (T)mapping.Value;
			}
			else
			{
				return (T)Activator.CreateInstance((Type)mapping.Value);
			}
		}

		internal protected void SetMappings(MappingCollection mappings)
		{
			_mapping = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}
	}
}