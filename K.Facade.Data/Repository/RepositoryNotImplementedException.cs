using System;

namespace K.Facade.Data.Repository
{
	[Serializable]
	public class RepositoryNotImplementedException : Exception
	{
		public RepositoryNotImplementedException(string @interface, string @ref) : base($"Interface [{@interface}] not inherit [{@ref}].")
		{
		}
	}
}
