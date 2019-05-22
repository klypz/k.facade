using K.Facade.Structure;
using System;

namespace K.Facade
{
	internal class FactoryMapping : IFactoryMapping
	{
		private readonly IFacadeMapper _mapper;

		public FactoryMapping(IFacadeMapper mapper)
		{
			_mapper = mapper;
		}
		public void Map(Action<IFacadeMapper> mapper)
		{
			mapper.Invoke(_mapper);
		}

		public void MapAll()
		{
			throw new NotImplementedException();
		}

		public void MapAll(string jsonFile)
		{
			throw new NotImplementedException();
		}
	}
}
