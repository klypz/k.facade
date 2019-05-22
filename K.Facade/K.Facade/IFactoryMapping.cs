using K.Facade.Structure;
using System;

namespace K.Facade
{
	public interface IFactoryMapping
	{
		void Map(Action<IFacadeMapper> mapper);
		void MapAll();
		void MapAll(string jsonFile);
	}
}
