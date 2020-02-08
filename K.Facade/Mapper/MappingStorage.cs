using K.Facade.Abstracts;
using System;
using System.Linq;

namespace K.Facade.Mapper
{
	internal class MappingStore : IMappingStorage
	{
		protected MappingCollection Mappings { get; set; }

		internal MappingStore(MappingCollection mappings)
		{
			Mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}

		public event MappingStoreAddHandler OnBeforeAdd;

		public virtual IMappingStorage Add(Type @interface, object value, string target)
		{
			if (@interface == null)
			{
				throw new ArgumentNullException(nameof(@interface));
			}

			if (string.IsNullOrEmpty(target))
			{
				throw new ArgumentException("message", nameof(target));
			}

			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			if (!IsValueValid(@interface, value))
			{
				throw new InterfaceNotImplementedException(@interface, value);
			}

			var Add = new Mapping(@interface, value, target);

			if (!Mappings.Any(a => a.CompareTo(Add) >= 2))
			{
				OnBeforeAdd?.Invoke(@interface, value, target);
				Mappings.Add(Add);
			}

			return this;
		}

		public virtual IMappingStorage Add(Type @interface, object value)
		{
			if (@interface == null)
			{
				throw new ArgumentNullException(nameof(@interface));
			}

			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			if (!IsValueValid(@interface, value))
			{
				throw new InterfaceNotImplementedException(@interface, value);
			}

			var mappgin = new Mapping(@interface, value);

			if (!Mappings.Any(a => a.CompareTo(mappgin) >= 2))
			{
				OnBeforeAdd?.Invoke(@interface, value, null);
				Mappings.Add(mappgin);
			}

			return this;
		}

		public virtual IMappingStorage Add<T>(T value)
		{
			return Add(typeof(T), value);
		}

		public virtual IMappingStorage Add<T>(T value, string target)
		{
			return Add(typeof(T), value, target);
		}

		public virtual IMappingStorage Add<T, TValue>() where TValue : T, new()
		{
			return Add(typeof(T), typeof(TValue));
		}

		public virtual IMappingStorage Add<T, TValue>(string target) where TValue : T, new()
		{
			return Add(typeof(T), typeof(TValue), target);
		}

		private bool IsValueValid(Type @interface, object value)
		{
			bool funcResult(Type type)
			{
				return type.GetInterfaces().Any(a => a == @interface);
			}

			return (value.GetType() == typeof(Type).GetType()) ? funcResult((Type)value) : funcResult(value.GetType());
		}
	}
}
