using K.Facade.Structure;

namespace K.Facade.DomainFacade
{
	public class FacadeMapper : IFacadeMapperWithMapping
	{
		private MappingCollection _mappings;
		public void Add<T>(T value)
		{
			_mappings.Add(new Mapping { Facade = typeof(T), Value = value });
		}

		public void Add<T>(T value, string target)
		{
			_mappings.Add(new Mapping { Facade = typeof(T), Value = value, Target = target });
		}

		public void Add<T, TValue>() where TValue : T, new()
		{
			_mappings.Add(new Mapping { Facade = typeof(T), Value = typeof(TValue), Target = null });
		}

		public void Add<T, TValue>(string target) where TValue : T, new()
		{
			_mappings.Add(new Mapping { Facade = typeof(T), Value = typeof(TValue), Target = target });
		}

		public void SetMappings(MappingCollection mappings)
		{
			_mappings = mappings;
		}
	}
}