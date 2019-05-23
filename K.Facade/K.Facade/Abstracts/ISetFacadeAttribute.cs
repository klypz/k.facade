using System;

namespace K.Facade.Abstracts
{
	public interface ISetFacadeAttribute
	{
		Type Facade { get; }
		string Target { get; }
	}
}