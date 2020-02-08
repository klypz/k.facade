using System;

namespace K.Facade.Mapper
{
	public sealed class Mapping : IEquatable<Mapping>, IComparable<Mapping>
	{
		public Mapping(Type facade, object value, string target) : this(facade, value)
		{
			Target = target;
		}
		public Mapping(Type facade, object value)
		{
			Facade = facade;
			Value = value;
		}
		public Type Facade { get; }
		public string Target { get; } = null;
		public object Value { get; }

		public MappingModeEnum Mode
		{
			get
			{
				if (Value.GetType() == typeof(Type).GetType())
				{
					return MappingModeEnum.Type;
				}
				else
				{
					return MappingModeEnum.Instanced;
				}
			}
		}

		public int CompareTo(Mapping other)
		{
			int result = 0;

			result += other.Facade == Facade ? 1 : 0;
			result += other.Target == Target ? 1 : 0;

			return result;
		}

		public bool Equals(Mapping other)
		{
			return Facade.FullName == other.Facade.FullName && other.Target == Target && other.Value.GetType().FullName == Value.GetType().FullName;
		}
	}
}
