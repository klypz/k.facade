using System;

namespace K.Facade.Auxiliars
{
    internal class Register : IEquatable<Register>, IComparable<Register>
    {
        public Type Interface { get; set; }
        public string Target { get; set; } = null;
        public object Value { get; set; }

        public bool IsType { get
            {
                return Value.GetType() == typeof(Type).GetType();
            }
        }

        public Register(Type @interface, object value)
        {
            Interface = @interface;
            Value = value;
        }

        public Register(Type @interface, object value, string target): this(@interface, value)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentException("message", nameof(target));
            }

            Target = target;
        }

        public bool Equals(Register other)
        {
            return other.Interface.FullName == other.Interface.FullName &&
                other.Target == Target &&
                other.Value.GetType().FullName == Value.GetType().FullName;
        }

        public int CompareTo(Register other)
        {
            int result = 0;

            result += other.Interface == Interface ? 1 : 0;
            result += other.Target == Target ? 1 : 0;

            return result;

        }
    }
}
