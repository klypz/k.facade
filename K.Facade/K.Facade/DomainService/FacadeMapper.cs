using K.Facade.Structure;
using System;
using System.Linq;

namespace K.Facade.DomainService
{
	public class FacadeMapper : IFacadeMapper
	{
		protected MappingCollection Mappings { get; set; }

		public virtual IFacadeMapper Add(Type @interface, object value, string target)
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
				throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
			}

			var Add = new Mapping(@interface, value, target);

			if (!Mappings.Any(a => a.CompareTo(Add) >= 2))
			{
				Mappings.Add(Add);
			}

			return this;
		}

		public virtual IFacadeMapper Add(Type @interface, object value)
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
				throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
			}

			var mappgin = new Mapping(@interface, value);

			if (!Mappings.Any(a => a.CompareTo(mappgin) >= 2))
			{
				Mappings.Add(mappgin);
			}

			return this;
		}

		public virtual IFacadeMapper Add<T>(T value)
		{
			return Add(typeof(T), value);
		}

		public virtual IFacadeMapper Add<T>(T value, string target)
		{
			return Add(typeof(T), value, target);
		}

		public virtual IFacadeMapper Add<T, TValue>() where TValue : T, new()
		{
			return Add(typeof(T), typeof(TValue));
		}

		public virtual IFacadeMapper Add<T, TValue>(string target) where TValue : T, new()
		{
			return Add(typeof(T), typeof(TValue), target);
		}

		protected Action<Type, Type> ValidateType { get; set; }

		private bool IsValueValid(Type @interface, object value)
		{
			bool funcResult(Type type)
			{
				ValidateType?.Invoke(@interface, type);

				return type.GetInterfaces().Any(a => a == @interface);
			}

			return (value.GetType() == typeof(Type).GetType()) ? funcResult((Type)value) : funcResult(value.GetType());
		}

		protected internal void SetMappings(MappingCollection mappings)
		{
			Mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}
	}
}