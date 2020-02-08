using System;

namespace K.Facade.Abstracts
{
	public delegate void MappingStoreAddHandler(Type @interface, object value, string target);

	public interface IMappingStorage
	{
		event MappingStoreAddHandler OnBeforeAdd;
		IMappingStorage Add(Type @interface, object value);
		IMappingStorage Add(Type @interface, object value, string target);
		IMappingStorage Add<T, TValue>() where TValue : T, new();
		IMappingStorage Add<T, TValue>(string target) where TValue : T, new();
		IMappingStorage Add<T>(T value);
		IMappingStorage Add<T>(T value, string target);
	}
}
