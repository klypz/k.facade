using K.Facade.Structure;
using System;
using System.Linq;

namespace K.Facade.DomainFacade
{
	public class FacadeMapper : IFacadeMapper
	{
		private MappingCollection _mapping;

		protected FacadeMapper()
		{

		}

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

			if (!_mapping.Any(a => a.CompareTo(Add) >= 2))
			{
				_mapping.Add(Add);
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

			if (!_mapping.Any(a => a.CompareTo(mappgin) >= 2))
			{
				_mapping.Add(mappgin);
			}

			return this;
		}

		public virtual IFacadeMapper Add<T>(T value)
		{
			Add(typeof(T), value);
		}

		public virtual IFacadeMapper Add<T>(T value, string target)
		{
			Add(typeof(T), target, value);
		}

		public virtual IFacadeMapper Add<T, TValue>() where TValue : T, new()
		{
			Add(typeof(T), typeof(TValue));
		}

		public virtual IFacadeMapper Add<T, TValue>(string target) where TValue : T, new()
		{
			Add(typeof(T), typeof(TValue), target);
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

		internal void SetMappings(MappingCollection mappings)
		{
			_mapping = mappings ?? throw new ArgumentNullException(nameof(mappings));
		}
	}
}