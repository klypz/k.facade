using System;

namespace K.Facade.Structure
{
	public sealed class Mapping
	{
		public Type Facade { get; set; }
		public string Target { get; set; }
		public object Value { get; set; }

		public MappingModeEnum Mode
		{
			get
			{
				if(Value.GetType() == typeof(Type))
				{
					return MappingModeEnum.Type;
				}
				else
				{
					return MappingModeEnum.Instanced;
				}
			}
		}
	}
}
