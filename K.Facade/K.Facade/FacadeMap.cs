using System;

namespace K.Facade
{
    sealed class FacadeMap
    {
        public Type Facade { get; private set; }
        public object Instance { get; private set; }
        public string Target { get; private set; } = null;

        public bool IsObject
        {
            get
            {
                return Instance.GetType() != typeof(Type).GetType();
            }
        }

        public FacadeMap(Type facade, object @instance)
        {
            if (facade == null)
            {
                throw new ArgumentNullException(nameof(facade));
            }

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!facade.IsInterface)
            {
                throw new InvalidFacadeMapException($"Facade [{facade.Name}] não é uma interface");
            }

            Type type = (instance.GetType() == typeof(Type).GetType()) ? (Type)instance : instance.GetType();

            if (!type.IsClass)
            {
                throw new InvalidFacadeMapException($"Instância [{type.Name}] não é uma classe não é uma interface");
            }

            if (type.GetInterface(facade.FullName) == null)
            {
                throw new InvalidFacadeMapException($"Instância [{type.Name}] não implementa a facade [{facade.Name}].");
            }
            Facade = facade;
            Instance = instance;
        }

        public FacadeMap(Type facade, string target, object @instance) : this(facade, @instance)
        {
            Target = target;
        }
    }
}
