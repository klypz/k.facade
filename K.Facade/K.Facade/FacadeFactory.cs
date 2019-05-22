using System;
using System.Collections.Generic;

namespace K.Facade
{
	public static class FacadeFactory<T> where T: IFactory
	{
		private static Dictionary<Type, Type> MappingFactory { get; set; } = new Dictionary<Type, Type>();

		private static void ScanAssemblies()
		{
			string file = FacadeConfiguration.ConfigurationFile;
		}
	}
}
