using K.Facade.Structure;

namespace K.Facade
{
	public abstract class FacadeFactoryBase : IFactory
	{
		protected MappingCollection _mappings;
		protected IFacadeMapper FacadeMapper { get; private set; }
		protected IFacadeFactory FacadeFactory { get; private set; }
		public IFactoryMapping Map { get; private set; }

		protected FacadeFactoryBase(IFacadeMapper facadeMapper, IFacadeFactory facadeFactory, MappingCollection mappings)
		{
			_mappings = mappings;
			FacadeFactory = facadeFactory;
			FacadeMapper = facadeMapper;

			Map = new FactoryMapping(FacadeMapper);
		}

		public virtual T GetInstance<T>()
		{
			return FacadeFactory.GetInstance<T>();
		}

		public virtual T GetInstance<T>(string target)
		{
			return FacadeFactory.GetInstance<T>(target);
		}
	}
}
