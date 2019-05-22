using K.Facade.Structure;
using System;

namespace K.Facade
{
	public abstract class FacadeFactory
	{
		private MappingCollection _mappings = new MappingCollection();
		private IFacadeLoadMapper _loadMapper;
		private IFacadeMapper _mapper;
		private IFacadeFactory _factory;
		private string _configurationFile;

		protected void SetLoadMapper(IFacadeLoadMapperWithMapping loadMapper)
		{
			loadMapper.SetMappings(_mappings);
			_loadMapper = loadMapper ?? throw new ArgumentNullException(nameof(loadMapper));
		}

		protected void SetFacadeMapper(IFacadeMapperWithMapping mapper)
		{
			mapper.SetMappings(_mappings);
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		protected void SetFacadeFactory(IFacadeFactoryWithMapping factory)
		{
			factory.SetMappings(_mappings);
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
		}

		protected void SetConfigurationFileDefault(string configurationFile)
		{
			_configurationFile = configurationFile;
		}

		public T GetInstance<T>()
		{
			return _factory.GetInstance<T>();
		}

		public T GetInstance<T>(string target)
		{
			return _factory.GetInstance<T>(target);
		}

		public void LoadMapping() {
			LoadMapping(_configurationFile);
		}
		public void LoadMapping(string jsonFile)
		{
			_loadMapper.Load(jsonFile);
		}

		public void Mapping(Action<IFacadeMapper> mapper)
		{
			mapper.Invoke(_mapper);
		}
	}
}