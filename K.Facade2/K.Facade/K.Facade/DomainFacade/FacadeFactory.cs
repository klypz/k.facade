using K.Facade.Structure;
using System;

namespace K.Facade.DomainFacade
{
	public class FacadeFactory : IFacadeFactoryWithMapping
	{
		private MappingCollection _mappings;

		public virtual T GetInstance<T>()
		{
			return GetInstance<T>(null);
		}

		public virtual T GetInstance<T>(string target)
		{
			if (_mappings == null)
			{
				throw new FacadeException("MAPPING_COLLECTION_IS_NOT_DEFINED");
			}

			if (_mappings.Contains(new Mapping { Facade = typeof(T), Target = target }))
			{
				Mapping map = _mappings.Get(typeof(T), target);

				if (map != null)
				{
					if (map.Mode == MappingModeEnum.Instanced)
					{
						return (T)map.Value;
					}
					else
					{
						return (T)Activator.CreateInstance((Type)map.Value);
					}
				}
				else
				{
					throw new FacadeException("FACADE_NOT_FOUND", typeof(T).Name, target);
				}
			}
			else
			{
				throw new FacadeException("FACADE_NOT_FOUND", typeof(T).Name, target);
			}
		}

		public virtual void SetMappings(MappingCollection mappings)
		{
			_mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}
	}
}