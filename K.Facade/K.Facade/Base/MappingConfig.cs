using System;
using System.Collections.Generic;
using System.Linq;

namespace K.Facade.Base
{
    public class MappingConfig : IMappingConfig
    {
        internal List<Register> Registers { get; private set; } = new List<Register>();

        public MappingConfig()
        {

        }

        public virtual void Register(Type @interface, string target, object value)
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
            if (value.GetType() == typeof(Type).GetType())
            {
                if (!((Type)value).GetInterfaces().Any(a => a == @interface))
                {
                    throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
                }
            }
            else
            {
                if (!value.GetType().GetInterfaces().Any(a => a == @interface))
                {
                    throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
                }
            }

            var register = new Register(@interface, value, target);

            if (!Registers.Any(a => a.CompareTo(register) >= 2))
            {
                Registers.Add(register);
            }
        }

        public virtual object GetRegister(Type type)
        {
            return GetRegister(type, (string)null);
        }
        public virtual object GetRegister(Type type, string target)
        {
            if (!Registers.Any(a => a.Interface == type && a.Target == target))
            {
                throw new InstanceForFacadeNotFoundException(type.Name);
            }

            var register = Registers.FirstOrDefault(a => a.Interface == type && a.Target == target);

            if (register.IsType)
            {
                return Activator.CreateInstance((Type)register.Value);
            }
            else
            {
                return register.Value;
            }
        }

        public virtual object GetRegister(Type type, params object[] constructor)
        {
            return GetRegister(type, null, constructor);
        }
        public virtual object GetRegister(Type type, string target, params object[] constructor)
        {
            if (!Registers.Any(a => a.Interface == type && a.Target == target))
            {
                throw new InstanceForFacadeNotFoundException(type.Name);
            }

            var register = Registers.FirstOrDefault(a => a.Interface == type && a.Target == target);

            if (register.IsType)
            {
                return Activator.CreateInstance((Type)register.Value, constructor);
            }
            else
            {
                return register.Value;
            }
        }

        public virtual void Register(Type @interface, object value)
        {
            if (@interface == null)
            {
                throw new ArgumentNullException(nameof(@interface));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.GetType() == typeof(Type).GetType())
            {
                if (!((Type)value).GetInterfaces().Any(a => a == @interface))
                {
                    throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
                }
            }
            else
            {
                if (!value.GetType().GetInterfaces().Any(a => a == @interface))
                {
                    throw new FacadeNotImplementedException(value.GetType().Name, @interface.Name);
                }
            }
            var register = new Register(@interface, value);

            if (!Registers.Any(a => a.CompareTo(register) >= 2))
            {
                Registers.Add(register);
            }
        }

        public virtual void Register<T>(T value)
        {
            Register(typeof(T), value);
        }

        public virtual void Register<T>(string target, T value)
        {
            Register(typeof(T), target, value);
        }

        public virtual void Register<T, TValue>() where TValue : T, new()
        {
            Register(typeof(T), typeof(TValue));
        }

        public virtual void Register<T, TValue>(string target) where TValue : T, new()
        {
            Register(typeof(T), target, typeof(TValue));
        }
    }
}
