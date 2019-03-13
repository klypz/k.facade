using K.Facade.Contracts;
using System;
using System.Linq;

namespace K.Facade
{
    sealed class Mapping : IMap, IFactory
    {
        private FacadeCollection Mappings { get; set; } = new FacadeCollection();

        public T GetInstance<T>()
        {
            return GetInstance<T>(null);
        }

        public T GetInstance<T>(string target)
        {
            if (Mappings.Any(a => a.Facade == typeof(T) && a.Target == target))
            {
                FacadeMap map = Mappings[typeof(T), target];

                if (map.IsObject)
                {
                    return (T)map.Instance;
                }
                else
                {
                    return (T)Activator.CreateInstance((Type)map.Instance);
                }
            }
            else
            {
                throw new TypeNotFoundException(typeof(T).FullName);
            }
        }

        public bool HasInstance<T>()
        {
            return HasInstance<T>(null);
        }

        public bool HasInstance<T>(string target)
        {
            return Mappings.Any(a => a.Facade == typeof(T) && a.Target == target);
        }

        public bool TryGetInstance<T>(out T output)
        {
            try
            {
                output = GetInstance<T>();
                return true;
            }
            catch
            {
                output = default(T);
                return false;
            }
        }

        public bool TryGetInstance<T>(string target, out T output)
        {
            try
            {
                output = GetInstance<T>(target);
                return true;
            }
            catch
            {
                output = default(T);
                return false;
            }
        }

        public void Map<TInterface, TClass>() where TClass : TInterface, new()
        {
            Map(typeof(TInterface), typeof(TClass));
        }

        public void Map<TInterface, TClass>(string target) where TClass : TInterface, new()
        {
            Map(typeof(TInterface), target, typeof(TClass));
        }

        public void Map<TInterface>(TInterface @object)
        {
            Mappings.Add(new FacadeMap(typeof(TInterface), @object));
        }

        public void Map<TInterface>(string target, TInterface @object)
        {
            Mappings.Add(new FacadeMap(typeof(TInterface), target, @object));
        }

        public void Map(Type @interface, Type f)
        {
            Mappings.Add(new FacadeMap(@interface, f));
        }

        public void Map(Type @interface, string target, Type f)
        {
            Mappings.Add(new FacadeMap(@interface, target, f));
        }

        public void Map(Type @interface, object f)
        {
            Mappings.Add(new FacadeMap(@interface, f));
        }

        public void Map(Type @interface, string target, object f)
        {
            Mappings.Add(new FacadeMap(@interface, target, f));
        }
    }
}
