using K.Facade.DomainService;
using K.Facade.Structure;
using System;
using System.Linq;
using DOM = K.Facade.DomainService;

namespace K.Facade.Data.Repository
{
	internal class RepositoryFactory : DOM.FacadeFactory
	{
		internal protected new void SetMappings(MappingCollection mappings)
		{
			base.SetMappings(mappings);
		}
	}

	internal class RepositoryMapper : FacadeMapper
	{
		public RepositoryMapper()
		{
			ValidateType = delegate (Type @interface, Type value)
			{
				if(!@interface.GetInterfaces().Any(a=>a == typeof(IRepository)))
				{
					throw new RepositoryNotImplementedException(@interface.FullName, typeof(IRepository).Name);
				}
			};
		}

		internal protected new void SetMappings(MappingCollection mappings)
		{
			base.SetMappings(mappings);
		}
	}
}
