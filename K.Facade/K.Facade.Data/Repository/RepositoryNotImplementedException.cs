using K.Facade.Structure;
using System;

namespace K.Facade.Data.Repository
{
	[Serializable]
	public class RepositoryNotImplementedException : KFacadeException
	{
		public RepositoryNotImplementedException(string @interface, string @ref) : base($"Interface [{@interface}] not inherit [{@ref}].")
		{
		}
	}
}
