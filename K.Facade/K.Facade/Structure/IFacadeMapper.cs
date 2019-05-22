using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade.Structure
{
	public interface IFacadeMapper
	{
		IFacadeMapper Add(Type @interface, object value);
		IFacadeMapper Add(Type @interface, object value, string target);
		IFacadeMapper Add<T, TValue>() where TValue : T, new();
		IFacadeMapper Add<T, TValue>(string target) where TValue : T, new();
		IFacadeMapper Add<T>(T value);
		IFacadeMapper Add<T>(T value, string target);
	}
}
