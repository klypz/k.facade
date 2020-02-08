using System;
using System.Linq;
using K.Facade.Mapper;

namespace K.Facade.Data.Repository
{
	public class MappingRepositoryFactory : MappingFactory
	{
		public MappingRepositoryFactory(MappingCollection mappings, string assembliesField, Type attributeSearch) : base(mappings, assembliesField, attributeSearch)
		{
			Mapper.OnBeforeAdd += Mapper_OnBeforeAdd;
		}

		private void Mapper_OnBeforeAdd(Type @interface, object value, string target)
		{
			if (!@interface.GetInterfaces().Any(a => a == typeof(IRepository)))
			{
				throw new RepositoryNotImplementedException(@interface.FullName, typeof(IRepository).Name);
			}
		}
	}
}
