using System;

namespace K.Facade.Mapper
{
	[Serializable]
	public class InterfaceNotImplementedException : MapperException
	{
		public InterfaceNotImplementedException(Type @interface, object value)
			: base($"Interface [{@interface.Name}] not implemented in [{(value.GetType() == typeof(Type).GetType() ? ((Type)value).Name : value.GetType().Name)}]")
		{

		}
	}
}
