using System;

namespace K.Facade.Abstracts
{
	public interface IMappingFactory
	{
		void Map(Action<IMappingStorage> map);

		void LoadMapping();

		void LoadMapping(string jsonConfig);
	}
}