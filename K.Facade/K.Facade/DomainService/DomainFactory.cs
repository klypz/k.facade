using K.Facade.Structure;

namespace K.Facade.DomainService
{
	public class DomainFactory : FacadeFactoryBase
	{
		internal DomainFactory() : base(new FacadeMapper(), new FacadeFactory(), new MappingCollection())
		{
			((FacadeMapper)FacadeMapper).SetMappings(_mappings);
			((FacadeFactory)FacadeFactory).SetMappings(_mappings);
		}
	}
}
