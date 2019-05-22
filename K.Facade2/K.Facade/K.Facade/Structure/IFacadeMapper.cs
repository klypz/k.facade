using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade.Structure
{
	public interface IFacadeMapper
	{
		void Add<T, TValue>() where TValue: T, new();
		void Add<T, TValue>(string target) where TValue : T, new();
		void Add<T>(T value);
		void Add<T>(T value, string target);
	}
}
