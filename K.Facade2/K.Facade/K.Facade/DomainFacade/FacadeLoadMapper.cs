using K.Facade.Structure;
using System;

namespace K.Facade.DomainFacade
{
	public class FacadeLoadMapper : IFacadeLoadMapperWithMapping
	{
		private MappingCollection _mappings;

		protected string[] RouteJsonField { get; set; }

		public FacadeLoadMapper(string routeJsonField = "map/domain")
		{
			RouteJsonField = $"k.facade/{routeJsonField}".Split('/');
		}

		public void Load(string file)
		{
			throw new NotImplementedException();
		}

		public void LoadJsonString(string json)
		{
			throw new NotImplementedException();
		}

		public void SetMappings(MappingCollection mappings)
		{
			_mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}

		protected void LoadAssemblies()
		{

		}
	}
}