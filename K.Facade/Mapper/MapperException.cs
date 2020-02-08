using System;

namespace K.Facade.Mapper
{
	[Serializable]
	public class MapperException : Exception
	{
		public MapperException(string message) : base(message)
		{

		}
	}


	[Serializable]
	public class DuplicateKeyException : MapperException
	{
		public DuplicateKeyException(string facade, string target)
			: base($"Duplicate keys: facade: [{facade}]{(!string.IsNullOrEmpty(target) ? $" - target: [{target}]" : "")}")
		{

		}
	}
}
